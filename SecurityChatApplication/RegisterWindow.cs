using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using AccountMsg;

namespace SecurityChatApplication
{
    public partial class RegisterWindow : Form
    {
        private ChatClient chatclient_Reg;
        Thread thread_Reg;
        private delegate void closeWindowDelegate();      
        public RegisterWindow()
        {
            InitializeComponent();
            thread_Reg = new Thread(readAccountStr);
            chatclient_Reg = new ChatClient("127.0.0.1", 9001);          
        }
        private void closeWindow()
        {
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Register_Click(object sender, EventArgs e)
        {
            if (textBox2_Password.Text != textBox3_Password.Text)
            {
                MessageBox.Show("两次密码输入不一致");
                return;
            }
            AccountMessage loginAccountMessage = new AccountMessage();
            loginAccountMessage.UserName = textBox1_UserID.Text;
            loginAccountMessage.Password = textBox2_Password.Text;
            loginAccountMessage.NickName = textBox4_UserName.Text;
            loginAccountMessage.Sex = UserSex.UNKNOWN;
            loginAccountMessage.AFlag = AccountMessageFlag.REGISTER;

            if (chatclient_Reg.States == connectState.DISCONNECTED)
            {
                try
                {
                    chatclient_Reg.start();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("无法连接服务器，错误信息:" + ex.Message);
                }

            }
            chatclient_Reg.writeAccountStr(loginAccountMessage);
            if (thread_Reg.ThreadState == ThreadState.Unstarted)
            {
                thread_Reg.Start();
                thread_Reg.IsBackground = true;
            }
            
        }

        private void readAccountStr()
        {
            try
            {
                lock (this)
                {
                   
                    AccountMessage msg = new AccountMessage();
                    chatclient_Reg.readAccountStr(ref msg);
                    switch (msg.RFlag)
                    {
                        case RegisterFlag.SUCCESS:
                            {
                                MessageBox.Show("注册成功");                            
                                if (this.InvokeRequired)
                                {
                                    closeWindowDelegate d = new closeWindowDelegate(closeWindow);
                                    this.Invoke(d);
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                            break;
                        case RegisterFlag.FAILED_EXSIT_USERNAME:
                            MessageBox.Show("用户名已经存在");
                            break;
                        case RegisterFlag.FAILED_UNKNOWN:
                            MessageBox.Show("未知错误");
                            break;
                    }
                  
                }
            }
            catch (Exception ee)
            {
                chatclient_Reg.close();                
                thread_Reg.Abort();
            }



        }
        private void RegisterWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(chatclient_Reg.States == connectState.CONNECTED)
                chatclient_Reg.close();
            if (thread_Reg.ThreadState == ThreadState.Running || thread_Reg.ThreadState == ThreadState.Background)
            {
                try
                {
                    thread_Reg.Abort();
                }
                catch(Exception ee)
                {
                    
                }
            }
        }

        private void RegisterWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
