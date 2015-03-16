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
    public partial class LoginWindow : Form
    {
        private delegate void closeWindowDelegate(); 
        private ChatClient chatclient_Login;
        private string id;
        public string ID
        {
            get
            {
                return id;  
            }
        }
        Mutex mutex_Login;
        Thread thread_Login;
        public LoginWindow()
        {
            InitializeComponent();
            chatclient_Login = new ChatClient("127.0.0.1", 9001);            
          //  chatclient_Login = new ChatClient("192.168.1.103", 9001);            
            thread_Login = new Thread(readAccountStr);
            mutex_Login = new Mutex();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void closeWindow()
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountMessage loginAccountMessage = new AccountMessage();
            loginAccountMessage.UserName = textBox1_UserID.Text;
            loginAccountMessage.Password = textBox2_Password.Text;
            loginAccountMessage.AFlag = AccountMessageFlag.LOGIN;
            if (chatclient_Login.States == connectState.DISCONNECTED)
            {
                try
                {
                    chatclient_Login.start();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("无法连接服务器,错误信息：" + ex.Message);
                    return;
                }
            }
            chatclient_Login.writeAccountStr(loginAccountMessage);
            if (thread_Login.ThreadState == ThreadState.Unstarted)
            {
                thread_Login.Start();
                thread_Login.IsBackground = true;
            }

           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }

        private void readAccountStr()
        {
            bool states = true; 
            while (states)
            {
                try
                {
                    AccountMessage msg = new AccountMessage();
                    chatclient_Login.readAccountStr(ref msg);

                    switch (msg.LFlag)
                    {
                        case LoginFlag.SUCCESS:
                            MessageBox.Show("登录成功");
                            closeWindowDelegate d = new closeWindowDelegate(closeWindow);
                            id = textBox1_UserID.Text;
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;                            
                            //this.Invoke(d);
                            states = false;   
                            break;
                        case LoginFlag.INVALID_USERNAME:
                            MessageBox.Show("用户名不存在");
                            break;
                        case LoginFlag.INVALID_PASSWORD:
                            MessageBox.Show("密码错误");
                            break;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    chatclient_Login.close();
                  //  mutex_Login.ReleaseMutex();
                    thread_Login.Abort();
                }


            }
        }

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {         
            if(chatclient_Login.States == connectState.CONNECTED)
                chatclient_Login.close();
            if (thread_Login.ThreadState == ThreadState.Running)
                thread_Login.Abort();
        }

    }
}
