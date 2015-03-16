using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ChatMsg;
using System.Security.Cryptography;
namespace SecurityChatApplication
{
    public partial class ChatWindow : Form
    {
        private RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();//RSA密钥信息
        private ChatClient client;
        private friend fri;
        Mutex mutex;
        Thread thread;
        private string userName;
        private string toUser;//储存当前正在密钥协商的ID
        private string contentCache;//储存在密钥协商时要发送的字符串
        private Dictionary<string, string> friendKey = new Dictionary<string,string>();
        private delegate void SetTextDelegate(string value);
        private delegate void SetFriendDelegate(Dictionary<string, bool> friend);
        private delegate void SetFriendListDelegate(string userName, bool online);
        private bool loopStates;
        public ChatWindow()
        {
            InitializeComponent();
            client = new ChatClient();
            thread = new Thread(readStr);
            mutex = new Mutex();
            loopStates = true;
           
        }
        private void writeStr()
        {
           // client.writeStr(textBoxSend.Text);   
        }
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="key"></param>
        private string RSAEncrypt(string content, string publicKey)
        {
            RSACryptoServiceProvider rsaCrypt = new RSACryptoServiceProvider();
            rsaCrypt.FromXmlString(publicKey);
            byte[] cipherbytes;
            cipherbytes = rsaCrypt.Encrypt(
              Encoding.UTF8.GetBytes(content),
              false);
            return Convert.ToBase64String(cipherbytes);
        }
        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        private string RSADecrypt(string content, string privateKey)
        {
            RSACryptoServiceProvider rsaCrypt = new RSACryptoServiceProvider();
            rsaCrypt.FromXmlString(privateKey);
            byte[] cipherbytes;
            
            cipherbytes = rsaCrypt.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);

        }
        /// <summary>
        /// 生成AES密钥
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private string createAesKey(string userName)
        {
            string alphabeta = "abcdefghijklmnopqrstuvwxyz0123456789";
            string key = "";
            Random rd = new Random();
            
            for(int i = 0; i < 32; ++i)
            {
                key += alphabeta[rd.Next(0, 36)];
            }
            friendKey[userName] = key;
            return key;

        }
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        private string AESEncrypt(string encryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        private string AESDecrypt(string decryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        private void SetText(string str)
        {            
            textBoxContent.Text += str;
            textBoxContent.Text += Environment.NewLine;
        }
        private void SetFriendList(string userName, bool online)
        {
            if(online)
            {
                try
                {
                    listBoxFriend.Items.Add(userName);
                    listBoxFriendOffline.Items.Remove(userName);
                }
                catch(Exception ee)
                {

                }
            }
            else
            {
                try
                {
                    listBoxFriend.Items.Remove(userName);
                    listBoxFriendOffline.Items.Add(userName);
                }
                catch (Exception ee)
                {

                }
            }
        }
        private void SetFriendList(Dictionary<string, bool> friend)
        {
            listBoxFriend.Items.Clear();
            listBoxFriendOffline.Items.Clear();
            foreach (var obj in friend)
            {
                if (obj.Value == true)
                    listBoxFriend.Items.Add(obj.Key);
                else
                    listBoxFriendOffline.Items.Add(obj.Key);
            }
            //listBoxFriend.SelectedIndex = 0;

        }
        /// <summary>
        /// 接收信息
        /// </summary>
        private void readStr()
        {
            while (loopStates)
            {                
                try
                {
                    lock (this)
                    {
                        mutex.WaitOne();
                        ChatMessage msg = new ChatMessage();
                        client.readStr(ref msg);
                        switch(msg.Flag)
                        {
                            case ChatMessageFlag.NORMAL:
                            {
                                msg.MessageText = AESDecrypt(msg.MessageText, friendKey[msg.Sender]);
                                if (this.InvokeRequired)
                                {
                                    SetTextDelegate d = new SetTextDelegate(SetText);
                                    this.Invoke(d,  msg.Sender + ": " + msg.MessageText);
                                }
                                else
                                {
                                    this.textBoxContent.Text += msg.MessageText;
                                }
                                break;
                             }
                             ///更新好友列表
                            case ChatMessageFlag.UPDATELIST:
                            {
                                if (this.InvokeRequired)
                                {
                                    SetFriendDelegate d = new SetFriendDelegate(SetFriendList);
                                    this.Invoke(d, msg.Friend);
                                }
                                else
                                {
                                    SetFriendList(msg.Friend);
                                }
                                friendKey.Clear();
                                foreach(var obj in msg.Friend)
                                {
                                    friendKey.Add(obj.Key, "");
                                }
                                break;
                            }
                            case ChatMessageFlag.SEARCH_FRIEND:
                            {
                                if(msg.IsOk)
                                {
                                    fri.updateFriendList(msg.MessageText, msg.IsOk);
                                }
                                else
                                {
                                    fri.updateFriendList("未找到", msg.IsOk);
                                }
                                break;
                            }
                            case ChatMessageFlag.ADD_FRIEND:
                            {

                                MessageBox.Show(msg.MessageText);
                                break;
                            }
                             //增加在线列表的好友
                            case ChatMessageFlag.ADD_FRIENDLIST:
                            {
                                if (this.InvokeRequired)
                                {
                                    SetFriendListDelegate d = new SetFriendListDelegate(SetFriendList);
                                    this.Invoke(d, msg.MessageText, true);
                                }
                                else
                                {
                                    SetFriendList(msg.MessageText, true);
                                }
                                break;
                            }
                                //删除在线列表的好友
                            case ChatMessageFlag.DEL_FRIENDLIST:
                            {

                                if (this.InvokeRequired)
                                {
                                    SetFriendListDelegate d = new SetFriendListDelegate(SetFriendList);
                                    this.Invoke(d, msg.MessageText, false);
                                }
                                else
                                {
                                    SetFriendList(msg.MessageText, false);
                                }
                                friendKey[msg.MessageText] = "";
                                break;                               
                            }
                            case ChatMessageFlag.GET_RSA:
                            {
                                string rsaPublicKey = msg.MessageText;
                                ChatMessage message = new ChatMessage();
                                message.Sender = userName;
                                message.Receiver = msg.Sender;
                                message.Flag = ChatMessageFlag.AES_SYN;
                                message.MessageText = RSAEncrypt(friendKey[msg.Sender], rsaPublicKey);
                                client.writeStr(message);
                                break;
                            }
                            case ChatMessageFlag.AES_SYN:
                            {
                                string aesKey = RSADecrypt(msg.MessageText, rsa.ToXmlString(true));//RSA解密传来的AES密钥
                                friendKey[msg.Sender] = aesKey;
                                ChatMessage message = new ChatMessage();
                                message.Sender = userName;
                                message.Receiver = msg.Sender;
                                message.Flag = ChatMessageFlag.AES_ACK;
                                client.writeStr(message);
                                break;
                            }
                            case ChatMessageFlag.AES_ACK:
                            {
                                ChatMessage message = new ChatMessage();
                                message.Sender = userName;
                                message.Receiver = msg.Sender;
                                message.Flag = ChatMessageFlag.NORMAL;
                                message.MessageText = AESEncrypt(contentCache, friendKey[msg.Sender]);
                                client.writeStr(message);
                                break;
                            }
                        }
                

                        mutex.ReleaseMutex();
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    client.close();
                    mutex.ReleaseMutex();
                    thread.Abort();
                }                
               

            }
        }
   
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.start();
                MessageBox.Show("连接成功");
                thread.Start();
                thread.IsBackground = true;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

       /// <summary>
       /// 发送消息
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(listBoxFriend.SelectedItem == null)
            {
                return;
            }
             try
             {
                 ChatMessage msg = new ChatMessage();
                 if (friendKey[(string)listBoxFriend.SelectedItem] != "")
                 {
                     msg.MessageText = AESEncrypt(textBoxSend.Text, friendKey[(string)listBoxFriend.SelectedItem]); ;
                     msg.Receiver = (string)listBoxFriend.SelectedItem;
                     msg.Sender = userName;
                     msg.Flag = ChatMessageFlag.NORMAL;
                     client.writeStr(msg);
                 }
                 else
                 {
                     createAesKey((string)listBoxFriend.SelectedItem);
                     contentCache = textBoxSend.Text;
                     msg.Receiver = (string)listBoxFriend.SelectedItem;
                     msg.Sender = userName;
                     msg.Flag = ChatMessageFlag.GET_RSA;
                     client.writeStr(msg);
                 }
                 textBoxContent.Text += userName + ":" + textBoxSend.Text + System.Environment.NewLine;
                 textBoxSend.Text = "";
                 

             }
            catch(Exception ee)
             {
                MessageBox.Show(ee.Message);
                client.close();
                thread.Abort();
            }
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                Environment.Exit(0);
            userName = loginWindow.ID;
            try
            {
                client.start();
               
               // MessageBox.Show("连接成功");
                ChatMessage msg = new ChatMessage();
                msg.Flag = ChatMessageFlag.LOGIN;
                msg.Sender = userName;
                this.Text += " ID:" + userName;
                client.writeStr(msg);
                Thread.Sleep(1000);
                
                //发送RSA公钥
                ChatMessage msgPublicKey = new ChatMessage();
                msgPublicKey.Sender = userName;
                msgPublicKey.MessageText = rsa.ToXmlString(false);//导出公钥
                msgPublicKey.Flag = ChatMessageFlag.WRITE_RSA;
                client.writeStr(msgPublicKey);
                thread.Start();
                thread.IsBackground = true;
                updateList();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                Environment.Exit(-1);
            }
           
        }
        private void updateList()
        {
            ChatMessage newMsg = new ChatMessage();
            newMsg.Flag = ChatMessageFlag.UPDATELIST;
            newMsg.Sender = userName;
            client.writeStr(newMsg);
        }
        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (client.States == connectState.CONNECTED)
                {
                    ChatMessage msg = new ChatMessage();
                    msg.Sender = userName;
                    msg.Flag = ChatMessageFlag.LOGOUT;
                    client.writeStr(msg);
                    client.close();
                }
                loopStates = false;
                thread.Abort();
            }
            catch(Exception ee)
            {

            }
        }
        /// <summary>
        /// KEEPALIVE计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ChatMessage msg = new ChatMessage();               
                msg.Sender = userName;
                msg.Flag = ChatMessageFlag.KEEPALIVE;
                client.writeStr(msg);                
            }
            catch (Exception ee)
            {
                
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            fri = new friend(ref client, userName);
            fri.ShowDialog();
        }
        /// <summary>
        /// 更新好友列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            ChatMessage newMsg = new ChatMessage();
            newMsg.Flag = ChatMessageFlag.UPDATELIST;
            newMsg.Sender = userName;
            client.writeStr(newMsg);
        }
    }
}
