namespace ClientRegistrator
{
    partial class RegistrationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.btn_register = new System.Windows.Forms.Button();
            this.tb_firstname = new System.Windows.Forms.TextBox();
            this.label_firstname = new System.Windows.Forms.Label();
            this.label_lastname = new System.Windows.Forms.Label();
            this.tb_lastname = new System.Windows.Forms.TextBox();
            this.label_phone = new System.Windows.Forms.Label();
            this.tb_phone = new System.Windows.Forms.TextBox();
            this.label_login = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_phone_code = new System.Windows.Forms.TextBox();
            this.label_phone_plus = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.labe_balance = new System.Windows.Forms.Label();
            this.tb_balance = new System.Windows.Forms.TextBox();
            this.lamel_currency = new System.Windows.Forms.Label();
            this.btn_test_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(12, 232);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(120, 23);
            this.btn_register.TabIndex = 0;
            this.btn_register.Text = "Зарегистрировать";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_click);
            // 
            // tb_firstname
            // 
            this.tb_firstname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_firstname.Location = new System.Drawing.Point(12, 27);
            this.tb_firstname.Name = "tb_firstname";
            this.tb_firstname.PlaceholderText = "Имя";
            this.tb_firstname.Size = new System.Drawing.Size(486, 23);
            this.tb_firstname.TabIndex = 1;
            this.tb_firstname.TextChanged += new System.EventHandler(this.tb_firstname_TextChanged);
            this.tb_firstname.Validating += new System.ComponentModel.CancelEventHandler(this.tb_firstname_Validating);
            // 
            // label_firstname
            // 
            this.label_firstname.AutoSize = true;
            this.label_firstname.Location = new System.Drawing.Point(12, 9);
            this.label_firstname.Name = "label_firstname";
            this.label_firstname.Size = new System.Drawing.Size(31, 15);
            this.label_firstname.TabIndex = 2;
            this.label_firstname.Text = "Имя";
            // 
            // label_lastname
            // 
            this.label_lastname.AutoSize = true;
            this.label_lastname.Location = new System.Drawing.Point(12, 53);
            this.label_lastname.Name = "label_lastname";
            this.label_lastname.Size = new System.Drawing.Size(58, 15);
            this.label_lastname.TabIndex = 3;
            this.label_lastname.Text = "Фамилия";
            // 
            // tb_lastname
            // 
            this.tb_lastname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_lastname.Location = new System.Drawing.Point(12, 71);
            this.tb_lastname.Name = "tb_lastname";
            this.tb_lastname.PlaceholderText = "Фамилия";
            this.tb_lastname.Size = new System.Drawing.Size(486, 23);
            this.tb_lastname.TabIndex = 4;
            this.tb_lastname.TextChanged += new System.EventHandler(this.tb_lastname_TextChanged);
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Location = new System.Drawing.Point(12, 97);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(55, 15);
            this.label_phone.TabIndex = 5;
            this.label_phone.Text = "Телефон";
            // 
            // tb_phone
            // 
            this.tb_phone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_phone.Location = new System.Drawing.Point(73, 115);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.PlaceholderText = "29000000";
            this.tb_phone.Size = new System.Drawing.Size(425, 23);
            this.tb_phone.TabIndex = 6;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(12, 141);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(41, 15);
            this.label_login.TabIndex = 8;
            this.label_login.Text = "Логин";
            this.label_login.Click += new System.EventHandler(this.label2_Click);
            // 
            // tb_login
            // 
            this.tb_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_login.Location = new System.Drawing.Point(12, 159);
            this.tb_login.Name = "tb_login";
            this.tb_login.PlaceholderText = "some_login";
            this.tb_login.Size = new System.Drawing.Size(486, 23);
            this.tb_login.TabIndex = 9;
            // 
            // tb_phone_code
            // 
            this.tb_phone_code.Location = new System.Drawing.Point(28, 115);
            this.tb_phone_code.Name = "tb_phone_code";
            this.tb_phone_code.Size = new System.Drawing.Size(39, 23);
            this.tb_phone_code.TabIndex = 10;
            this.tb_phone_code.Text = "375";
            // 
            // label_phone_plus
            // 
            this.label_phone_plus.AutoSize = true;
            this.label_phone_plus.Location = new System.Drawing.Point(12, 118);
            this.label_phone_plus.Name = "label_phone_plus";
            this.label_phone_plus.Size = new System.Drawing.Size(15, 15);
            this.label_phone_plus.TabIndex = 11;
            this.label_phone_plus.Text = "+";
            this.label_phone_plus.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // btn_print
            // 
            this.btn_print.Enabled = false;
            this.btn_print.Location = new System.Drawing.Point(138, 232);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(90, 23);
            this.btn_print.TabIndex = 12;
            this.btn_print.Text = "Распечатать";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // labe_balance
            // 
            this.labe_balance.AutoSize = true;
            this.labe_balance.Location = new System.Drawing.Point(12, 185);
            this.labe_balance.Name = "labe_balance";
            this.labe_balance.Size = new System.Drawing.Size(113, 15);
            this.labe_balance.TabIndex = 13;
            this.labe_balance.Text = "Начальный баланс";
            // 
            // tb_balance
            // 
            this.tb_balance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_balance.Location = new System.Drawing.Point(12, 203);
            this.tb_balance.Name = "tb_balance";
            this.tb_balance.PlaceholderText = "2.5";
            this.tb_balance.Size = new System.Drawing.Size(463, 23);
            this.tb_balance.TabIndex = 14;
            this.tb_balance.Text = "0";
            this.tb_balance.TextChanged += new System.EventHandler(this.tb_balance_TextChanged);
            // 
            // lamel_currency
            // 
            this.lamel_currency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lamel_currency.AutoSize = true;
            this.lamel_currency.Location = new System.Drawing.Point(481, 206);
            this.lamel_currency.Name = "lamel_currency";
            this.lamel_currency.Size = new System.Drawing.Size(17, 15);
            this.lamel_currency.TabIndex = 15;
            this.lamel_currency.Text = "р.";
            // 
            // btn_test_print
            // 
            this.btn_test_print.Location = new System.Drawing.Point(395, 232);
            this.btn_test_print.Name = "btn_test_print";
            this.btn_test_print.Size = new System.Drawing.Size(115, 23);
            this.btn_test_print.TabIndex = 16;
            this.btn_test_print.Text = "Тестовая печать";
            this.btn_test_print.UseVisualStyleBackColor = true;
            this.btn_test_print.Visible = false;
            this.btn_test_print.Click += new System.EventHandler(this.btn_test_print_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 264);
            this.Controls.Add(this.btn_test_print);
            this.Controls.Add(this.lamel_currency);
            this.Controls.Add(this.tb_balance);
            this.Controls.Add(this.labe_balance);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label_phone_plus);
            this.Controls.Add(this.tb_phone_code);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.tb_phone);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.tb_lastname);
            this.Controls.Add(this.label_lastname);
            this.Controls.Add(this.label_firstname);
            this.Controls.Add(this.tb_firstname);
            this.Controls.Add(this.btn_register);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.Text = "Регистрация клиента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_register;
        private TextBox tb_firstname;
        private Label label_firstname;
        private Label label_lastname;
        private TextBox tb_lastname;
        private Label label_phone;
        private TextBox tb_phone;
        private Label label_login;
        private TextBox tb_login;
        private TextBox tb_phone_code;
        private Label label_phone_plus;
        private Button btn_print;
        private Label labe_balance;
        private TextBox tb_balance;
        private Label lamel_currency;
        private Button btn_test_print;
    }
}