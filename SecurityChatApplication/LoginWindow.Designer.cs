namespace SecurityChatApplication
{
    partial class LoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1_Login = new System.Windows.Forms.Button();
            this.button2_Forget = new System.Windows.Forms.Button();
            this.button3_Register = new System.Windows.Forms.Button();
            this.textBox1_UserID = new System.Windows.Forms.TextBox();
            this.textBox2_Password = new System.Windows.Forms.TextBox();
            this.checkBox1_RememberPassword = new System.Windows.Forms.CheckBox();
            this.checkBox2_AutoLogin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // button1_Login
            // 
            this.button1_Login.Location = new System.Drawing.Point(129, 316);
            this.button1_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1_Login.Name = "button1_Login";
            this.button1_Login.Size = new System.Drawing.Size(221, 29);
            this.button1_Login.TabIndex = 2;
            this.button1_Login.Text = "登 录";
            this.button1_Login.UseVisualStyleBackColor = true;
            this.button1_Login.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2_Forget
            // 
            this.button2_Forget.Location = new System.Drawing.Point(351, 221);
            this.button2_Forget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2_Forget.Name = "button2_Forget";
            this.button2_Forget.Size = new System.Drawing.Size(100, 29);
            this.button2_Forget.TabIndex = 3;
            this.button2_Forget.Text = "忘记密码";
            this.button2_Forget.UseVisualStyleBackColor = true;
            this.button2_Forget.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3_Register
            // 
            this.button3_Register.Location = new System.Drawing.Point(351, 116);
            this.button3_Register.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3_Register.Name = "button3_Register";
            this.button3_Register.Size = new System.Drawing.Size(100, 29);
            this.button3_Register.TabIndex = 4;
            this.button3_Register.Text = "注册账号";
            this.button3_Register.UseVisualStyleBackColor = true;
            this.button3_Register.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1_UserID
            // 
            this.textBox1_UserID.Location = new System.Drawing.Point(155, 116);
            this.textBox1_UserID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1_UserID.Name = "textBox1_UserID";
            this.textBox1_UserID.Size = new System.Drawing.Size(153, 25);
            this.textBox1_UserID.TabIndex = 5;
            // 
            // textBox2_Password
            // 
            this.textBox2_Password.Location = new System.Drawing.Point(155, 221);
            this.textBox2_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2_Password.Name = "textBox2_Password";
            this.textBox2_Password.Size = new System.Drawing.Size(153, 25);
            this.textBox2_Password.TabIndex = 6;
            // 
            // checkBox1_RememberPassword
            // 
            this.checkBox1_RememberPassword.AutoSize = true;
            this.checkBox1_RememberPassword.Location = new System.Drawing.Point(71, 268);
            this.checkBox1_RememberPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1_RememberPassword.Name = "checkBox1_RememberPassword";
            this.checkBox1_RememberPassword.Size = new System.Drawing.Size(89, 19);
            this.checkBox1_RememberPassword.TabIndex = 7;
            this.checkBox1_RememberPassword.Text = "记住密码";
            this.checkBox1_RememberPassword.UseVisualStyleBackColor = true;
            // 
            // checkBox2_AutoLogin
            // 
            this.checkBox2_AutoLogin.AutoSize = true;
            this.checkBox2_AutoLogin.Location = new System.Drawing.Point(237, 268);
            this.checkBox2_AutoLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox2_AutoLogin.Name = "checkBox2_AutoLogin";
            this.checkBox2_AutoLogin.Size = new System.Drawing.Size(89, 19);
            this.checkBox2_AutoLogin.TabIndex = 8;
            this.checkBox2_AutoLogin.Text = "自动登录";
            this.checkBox2_AutoLogin.UseVisualStyleBackColor = true;
            this.checkBox2_AutoLogin.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 396);
            this.Controls.Add(this.checkBox2_AutoLogin);
            this.Controls.Add(this.checkBox1_RememberPassword);
            this.Controls.Add(this.textBox2_Password);
            this.Controls.Add(this.textBox1_UserID);
            this.Controls.Add(this.button3_Register);
            this.Controls.Add(this.button2_Forget);
            this.Controls.Add(this.button1_Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginWindow";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginWindow_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1_Login;
        private System.Windows.Forms.Button button2_Forget;
        private System.Windows.Forms.Button button3_Register;
        private System.Windows.Forms.TextBox textBox1_UserID;
        private System.Windows.Forms.TextBox textBox2_Password;
        private System.Windows.Forms.CheckBox checkBox1_RememberPassword;
        private System.Windows.Forms.CheckBox checkBox2_AutoLogin;
    }
}