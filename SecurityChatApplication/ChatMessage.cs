using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatMsg
{
    [Serializable]
    public enum ChatMessageFlag
    {
        LOGIN,
        WRITE_RSA,
        GET_RSA,
        NORMAL,
        AES_SYN,
        AES_ACK,
        UPDATELIST,
        LOGOUT,
        KEEPALIVE,
        SEARCH_FRIEND,//搜索好友
        ADD_FRIEND,//添加好友
        ADD_FRIENDLIST,//在线好友列表添加好友
        DEL_FRIENDLIST, //在线好友列表删除好友
    }
    [Serializable]
    public class ChatMessage
    {
        private bool isOK;
        private string messageText;
        private string receiver;
        private string sender;
        private ChatMessageFlag flag;
        private Dictionary<string, bool> friend;
        public bool IsOk
        {
            get
            {
                return isOK;
            }
            set
            {
                isOK = value;
            }
        }
        public string MessageText
        {
            get
            {
                return messageText;
            }
            set
            {
                messageText = value;
            }
        }
        public string Receiver
        {
            get
            {
                return receiver;
            }
            set
            {
                receiver = value;
            }
        }
        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }
        public ChatMessageFlag Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }
        public Dictionary<string, bool> Friend
        {
            get
            {
                return friend;
            }
            set
            {
                friend = value;
            }
        }
    }
}
