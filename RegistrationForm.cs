using System.Security.Cryptography;
using System.Text;
using System.Web;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using Newtonsoft.Json;
using Ghostscript.NET.Processor;

namespace ClientRegistrator
{
    public partial class RegistrationForm : Form
    {

        const String LICENCE_ID = ""; // LICENCE ID HERE
        const String API_KEY = ""; // API_KEY_HERE
        const String API_SECRET = ""; // PASTE SECRET HERE

        const String API_BASE_URL = "https://cp.icafecloud.com/api/v1/";
        const String API_ENDPOINT_MEMBER = "member";

        public RegistrationForm()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        NameConverter nameConverter = new();

        private async void btn_register_click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_BASE_URL);

            long time = DateTimeOffset.Now.ToUnixTimeSeconds(); // Unix-time (seconds)

            Dictionary<String, String> paramList = new Dictionary<String, String>();

            var firstName = tb_firstname.Text.ToString();
            var lastName = tb_lastname.Text.ToString();
            var login = tb_login.Text.ToString();
            var phoneNumber = GetPhoneNumber();
            var password = new Random().Next(1, 999999).ToString("000000"); // Generate random 6-digit code
            var balanceText = tb_balance.Text.ToString().Replace(".", ","); 

            if (!validateForm(login, firstName, lastName, password, phoneNumber, balanceText))
            {
                return;
            }

            var balance = float.Parse(balanceText);

            paramList.Add("member_account", login);
            paramList.Add("member_password", password);
            paramList.Add("member_first_name", HttpUtility.UrlEncode(firstName, Encoding.UTF8).ToUpper());
            paramList.Add("member_last_name", HttpUtility.UrlEncode(lastName, Encoding.UTF8).ToUpper());
            paramList.Add("member_phone", HttpUtility.UrlEncode(phoneNumber, Encoding.UTF8).ToUpper());
            paramList.Add("member_balance", balance.ToString().Replace(",", "."));

            String query = buildQuery(paramList);

            var xAuthValue = buildAuthHeader(time, "POST", query);
            var xTimeValue = time.ToString();

            client.DefaultRequestHeaders.Add("X-Time", xTimeValue);
            client.DefaultRequestHeaders.Add("X-License-Id", LICENCE_ID);
            client.DefaultRequestHeaders.Add("X-Auth", xAuthValue);

            var uri = new Uri(API_BASE_URL + API_ENDPOINT_MEMBER);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new StringContent(query, Encoding.UTF8, "application/x-www-form-urlencoded");

            req.Headers.Add("X-Time", xTimeValue);
            req.Headers.Add("X-License-Id", LICENCE_ID);
            req.Headers.Add("X-Auth", xAuthValue);

            HttpResponseMessage result = await client.SendAsync(req);
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<CreateMemeberResponse>(result.Content.ReadAsStringAsync().Result);

                if (response.Result == 1)
                {
                    PrintCheck(firstName + " " + lastName, login, password);
                    btn_print.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Не удалось создать пользователя.\n\n" + response.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не удалось создать пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * This part was tested with Online-service for executing PHP code.
         * Generates exactly the same X-Auth header value as PHP code from example
         */
        private String buildAuthHeader(long time, String method, String query)
        {

            String signature = LICENCE_ID + "\x00" + API_KEY + "\x00" + time + "\x00" + method.ToUpper() + "\x00" + query; // got this from PHP sample
            String signHash = HashHmac(signature, API_SECRET);
            return API_KEY + ":" + signHash.ToLower();
        }

        /*
         * This part was tested with Online-service for executing PHP code.
         * Generates exactly the same hash as PHP
         */
        private static string HashHmac(string message, string secret)
        {
            var hashedBytes = HMACSHA256.HashData(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        /*
         * Builds query by concatenation "& + key + = + value"
         */
        public static string buildQuery(Dictionary<String, String> fields)
        {
            return $"{String.Join("&", fields.Select(pair => $"{pair.Key}={pair.Value}"))}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tb_firstname_TextChanged(object sender, EventArgs e)
        {
            updateLoginField();
        }

        private void tb_lastname_TextChanged(object sender, EventArgs e)
        {
            updateLoginField();
        }

        private void updateLoginField()
        {
            var firstName = tb_firstname.Text.ToString();
            var lastName = tb_lastname.Text.ToString();
            if (firstName != null && lastName != null)
            {
                tb_login.Text = nameConverter.convertFullNameToAccount(firstName, lastName);
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private String? GetPhoneNumber()
        {
            var countryCode = tb_phone_code.Text.ToString();
            var phone = tb_phone.Text.ToString();

            if (String.IsNullOrEmpty(countryCode) || String.IsNullOrEmpty(phone))
                return null;
            return "+" + countryCode + phone;
        }

        private bool validateForm(String? login, String? firstname, String? lastname, String? password, String? phone, String? balanceText)
        {
            var errorProvider = new ErrorProvider();
            if (string.IsNullOrEmpty(firstname))
            {
                ShowValidationErorr("Заполните имя");
                return false;
            }
            if (string.IsNullOrEmpty(lastname))
            {
                ShowValidationErorr("Заполните фамилию");
                return false;
            }
            if (string.IsNullOrEmpty(phone))
            {
                ShowValidationErorr("Заполните телефон");
                return false;
            }
            if (string.IsNullOrEmpty(login))
            {
                ShowValidationErorr("Логин должен быть не пустым");
                return false;
            }
            try
            {
                float.Parse(balanceText);
            }
            catch (Exception e)
            {
                ShowValidationErorr("Баланс пустой или неправильный формат числа");
                return false;
            }
            return true;
        }

        private void tb_firstname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintFile(AppContext.BaseDirectory + "check.pdf");
        }

        // Generate check PDF and print it
        private void PrintCheck(string name, string login, string password)
        {
            var termplateFile = AppContext.BaseDirectory + "check_template.pdf";
            var resultFile = AppContext.BaseDirectory + "check.pdf";
            var document = PdfReader.Open(termplateFile, PdfDocumentOpenMode.Modify);
            var page = document.Pages[0];
            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new("Arial", 11, XFontStyle.Bold);
            gfx.DrawString(name + "!", font, XBrushes.Black, new XRect(4, 90, 60, 30), XStringFormats.CenterLeft);
            gfx.DrawString(login, font, XBrushes.Black, new XRect(4, 205, 60, 30), XStringFormats.CenterLeft);
            gfx.DrawString(password, font, XBrushes.Black, new XRect(4, 235, 60, 30), XStringFormats.CenterLeft);
            document.Save(resultFile);
            try
            {
                PrintFile(resultFile);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при печати чека. Пользователь БЫЛ ЗАРЕГИСТРИРОВАН. Установите пароль вручную через панель icafe\n\n" + e.Message.ToString(), "Ошибка печати", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void PrintFile(string filename)
        {
            GhostscriptProcessor processor = new GhostscriptProcessor();
            List<string> switches = new List<string>();
            switches.Add("-empty");
            switches.Add("-dPrinted");
            switches.Add("-dBATCH");
            switches.Add("-dNOPAUSE");
            switches.Add("-dNOSAFER");
            switches.Add("-dNumCopies=1");
            switches.Add("-sDEVICE=mswinpr2");
            switches.Add("-sOutputFile=%printer%" + "G58");
            switches.Add("-f");
            switches.Add(filename);

            processor.StartProcessing(switches.ToArray(), null);
        }

        private void tb_balance_TextChanged(object sender, EventArgs e)
        {

        }

        private static void ShowValidationErorr(string message)
        {
            MessageBox.Show(message, "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_test_print_Click(object sender, EventArgs e)
        {
            PrintCheck("Niko Bellic", "123", "123");
        }
    }
}