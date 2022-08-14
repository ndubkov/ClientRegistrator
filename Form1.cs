using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ClientRegistrator
{
    public partial class Form1 : Form
    {

        const String LICENCE_ID = "67971"; // LICENCE ID HERE
        const String API_KEY = "d870f78a0ec85d73ebd95edbc53dcba46d04f48c"; // API_KEY_HERE
        const String API_SECRET = "ea3ca9ed7b51f1d2f7660e780ae6ccbb2230931c"; // PASTE SECRET HERE

        const String API_BASE_URL = "https://cp.icafecloud.com/api/v1/";
        const String API_ENDPOINT_MEMBER = "member";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_BASE_URL);

            long time = DateTimeOffset.Now.ToUnixTimeSeconds(); // Unix-time (seconds)

            Dictionary<String, String> paramList = new Dictionary<String, String>();

            paramList.Add("member_account", "test_api_1");
            paramList.Add("member_password", "test_api_pass");
            paramList.Add("member_first_name", "Niko");
            paramList.Add("member_last_name", "Bellic");
            paramList.Add("member_phone", "375291199711");

            String query = buildQuery(paramList);

            var xAuthValue = buildAuthHeader(time, "POST", query);
            var xTimeValue = time.ToString();

            client.DefaultRequestHeaders.Add("X-Time", xTimeValue);
            client.DefaultRequestHeaders.Add("X-License-Id", LICENCE_ID);
            client.DefaultRequestHeaders.Add("X-Auth", xAuthValue);

            var uri = new Uri(API_BASE_URL + API_ENDPOINT_MEMBER);
            //HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            
            // req.Headers.Add("X-Time", xTimeValue);
            //req.Headers.Add("X-License-Id", LICENCE_ID);
            //req.Headers.Add("X-Auth", xAuthValue);
            
            HttpResponseMessage result = await client.PostAsync(uri, new StringContent(query));

            result = result;

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
            return $"{String.Join("&", fields.Select(pair => $"{HttpUtility.UrlEncode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}"))}";
        }
    }
}