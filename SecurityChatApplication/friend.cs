using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChatMsg;
namespace SecurityChatApplication
{
    public partial class friend : Form
    {
        private delegate void updateDelegate(string str ,bool visible);
        private ChatClient client;
        private string userName;
        public friend(ref ChatClient client, string userName)
        {
            this.client = client;
            this.userName = userName;
            InitializeComponent();
        }
        public friend()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ChatMessage msg = new ChatMessage();                                
                msg.Sender = userName;
                msg.MessageText = textBox1.Text;
                msg.Flag = ChatMessageFlag.SEARCH_FRIEND;
                client.writeStr(msg);              
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                client.close();                
            }

        }

        private void friend_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 更新查找信息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="visible"></param>
        public void updateFriendList(string str, bool visible)
        {

            if (this.InvokeRequired)
            {
                updateDelegate d = new updateDelegate(setLabel);
                this.Invoke(d, str, visible);
            }
            else
            {
                setLabel(str, visible);
            }
           
        }
        public void setLabel(string str, bool visible)
        {
            labelResult.Text = str;
            buttonAdd.Visible = visible;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(userName == labelResult.Text)
            {
                MessageBox.Show("不能添加自己为好友");
            }
            else
            {

                try
                {
                    ChatMessage msg = new ChatMessage();
                    msg.Sender = userName;
                    msg.MessageText = textBox1.Text;
                    msg.Flag = ChatMessageFlag.ADD_FRIEND;
                    client.writeStr(msg);                   
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    client.close();
                }
            }
        }
    }
}
