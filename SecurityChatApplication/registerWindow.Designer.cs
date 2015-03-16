namespace SecurityChatApplication
{
    partial class RegisterWindow
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
            this.button1_Register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1_male = new System.Windows.Forms.RadioButton();
            this.radioButton_female = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton3_Secrecy = new System.Windows.Forms.RadioButton();
            this.textBox1_UserID = new System.Windows.Forms.TextBox();
            this.textBox2_Password = new System.Windows.Forms.TextBox();
            this.textBox3_Password = new System.Windows.Forms.TextBox();
            this.textBox4_UserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1_Register
            // 
            this.button1_Register.Location = new System.Drawing.Point(121, 326);
            this.button1_Register.Name = "button1_Register";
            this.button1_Register.Size = new System.Drawing.Size(89, 23);
            this.button1_Register.TabIndex = 0;
            this.button1_Register.Text = "立即注册";
            this.button1_Register.UseVisualStyleBackColor = true;
            this.button1_Register.Click += new System.EventHandler(this.button1_Register_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "确认密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "性别：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // radioButton1_male
            // 
            this.radioButton1_male.AutoSize = true;
            this.radioButton1_male.Location = new System.Drawing.Point(108, 230);
            this.radioButton1_male.Name = "radioButton1_male";
            this.radioButton1_male.Size = new System.Drawing.Size(35, 16);
            this.radioButton1_male.TabIndex = 5;
            this.radioButton1_male.TabStop = true;
            this.radioButton1_male.Text = "男";
            this.radioButton1_male.UseVisualStyleBackColor = true;
            this.radioButton1_male.CheckedChanged += new System.EventHandler(this.radioButton1_male_CheckedChanged);
            // 
            // radioButton_female
            // 
            this.radioButton_female.AutoSize = true;
            this.radioButton_female.Location = new System.Drawing.Point(149, 230);
            this.radioButton_female.Name = "radioButton_female";
            this.radioButton_female.Size = new System.Drawing.Size(35, 16);
            this.radioButton_female.TabIndex = 6;
            this.radioButton_female.TabStop = true;
            this.radioButton_female.Text = "女";
            this.radioButton_female.UseVisualStyleBackColor = true;
            this.radioButton_female.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "昵称：";
            // 
            // radioButton3_Secrecy
            // 
            this.radioButton3_Secrecy.AutoSize = true;
            this.radioButton3_Secrecy.Location = new System.Drawing.Point(190, 230);
            this.radioButton3_Secrecy.Name = "radioButton3_Secrecy";
            this.radioButton3_Secrecy.Size = new System.Drawing.Size(47, 16);
            this.radioButton3_Secrecy.TabIndex = 8;
            this.radioButton3_Secrecy.TabStop = true;
            this.radioButton3_Secrecy.Text = "保密";
            this.radioButton3_Secrecy.UseVisualStyleBackColor = true;
            // 
            // textBox1_UserID
            // 
            this.textBox1_UserID.Location = new System.Drawing.Point(108, 42);
            this.textBox1_UserID.Name = "textBox1_UserID";
            this.textBox1_UserID.Size = new System.Drawing.Size(143, 21);
            this.textBox1_UserID.TabIndex = 9;
            // 
            // textBox2_Password
            // 
            this.textBox2_Password.Location = new System.Drawing.Point(108, 98);
            this.textBox2_Password.Name = "textBox2_Password";
            this.textBox2_Password.Size = new System.Drawing.Size(143, 21);
            this.textBox2_Password.TabIndex = 10;
            // 
            // textBox3_Password
            // 
            this.textBox3_Password.Location = new System.Drawing.Point(108, 163);
            this.textBox3_Password.Name = "textBox3_Password";
            this.textBox3_Password.Size = new System.Drawing.Size(143, 21);
            this.textBox3_Password.TabIndex = 11;
            // 
            // textBox4_UserName
            // 
            this.textBox4_UserName.Location = new System.Drawing.Point(108, 280);
            this.textBox4_UserName.Name = "textBox4_UserName";
            this.textBox4_UserName.Size = new System.Drawing.Size(143, 21);
            this.textBox4_UserName.TabIndex = 12;
            // 
            // RegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 373);
            this.Controls.Add(this.textBox4_UserName);
            this.Controls.Add(this.textBox3_Password);
            this.Controls.Add(this.textBox2_Password);
            this.Controls.Add(this.textBox1_UserID);
            this.Controls.Add(this.radioButton3_Secrecy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButton_female);
            this.Controls.Add(this.radioButton1_male);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1_Register);
            this.Name = "RegisterWindow";
            this.Text = "registerWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterWindow_FormClosing);
            this.Load += new System.EventHandler(this.RegisterWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_Register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1_male;
        private System.Windows.Forms.RadioButton radioButton_female;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton3_Secrecy;
        private System.Windows.Forms.TextBox textBox1_UserID;
        private System.Windows.Forms.TextBox textBox2_Password;
        private System.Windows.Forms.TextBox textBox3_Password;
        private System.Windows.Forms.TextBox textBox4_UserName;
    }
}