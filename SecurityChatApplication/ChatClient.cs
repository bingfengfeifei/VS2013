using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChatMsg;
using AccountMsg;
namespace SecurityChatApplication
{
    public enum connectState
    {
        CONNECTED, DISCONNECTED
    }
   public  class ChatClient
    {
        public int id { get; set; }
        public BinaryReader br { get; set; }
        public BinaryWriter bw { get; set; }
        public int keepalive { get; set; }
        public connectState States
        {
            get
            {
                return state;
            }
        }
        public ChatClient()
        {
            tcp = new TcpClient();
            serverIP = "127.0.0.1";
            
        //    serverIP = "192.168.1.103";
            port = 9000;
            state = connectState.DISCONNECTED;
        }
        public ChatClient(string ip, int port)
        {
            tcp = new TcpClient();
            this.serverIP = ip;
            this.port = port;
            state = connectState.DISCONNECTED;
        }
        private bool connect()
        {
            tcp.Connect(serverIP, port);
            return tcp.Connected;
        }
        public void start()
        {
            if(connect())
            {
                state = connectState.CONNECTED;
                streamToServer = tcp.GetStream();
                br = new BinaryReader(streamToServer);
                bw = new BinaryWriter(streamToServer);
            }
            else
            {
                throw new Exception("cannot connect to server");
            }
        }
        public void readStr(ref ChatMessage receiveObject)
        {
           // const int BufferSize = 1024;
          //  byte[] buffer = new byte[BufferSize];
            
            try
            {
                byte[] bytes = new byte[10240];
                //停在此处，networkstream流中有新数据则读出
                int i = br.Read(bytes, 0, 10240);
                MemoryStream memory = new MemoryStream(bytes);
                BinaryFormatter format = new BinaryFormatter();
                format.Binder = new UBinder();
                receiveObject = (ChatMessage)format.Deserialize(memory);
            }
            catch (Exception)
            {
                return;
            }
           /* try
            {
                bytesRead = streamToServer.Read(buffer, 0, BufferSize);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Encoding.UTF8.GetString(buffer);*/
        }
        public void writeStr(ChatMessage sendObject)
        {
            /*byte[] buffer = Encoding.UTF8.GetBytes(str);

            try
            {
                streamToServer.Write(buffer, 0, buffer.Length);//buffer为发送的字符数组 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }*/
            try
            {
                MemoryStream memory = new MemoryStream();
                BinaryFormatter format = new BinaryFormatter();
                format.Serialize(memory, sendObject);
                byte[] bytes = memory.ToArray();

                bw.Write(bytes);
                bw.Flush();

            }
            catch (Exception e)
            {
                //发送失败
                throw new Exception(e.Message);
            }

        }

        public void readAccountStr(ref AccountMessage receiveObject)
        {
            // const int BufferSize = 1024;
            //  byte[] buffer = new byte[BufferSize];

            try
            {
                byte[] bytes = new byte[10240];
                //停在此处，networkstream流中有新数据则读出
                int i = br.Read(bytes, 0, 10240);
                MemoryStream memory = new MemoryStream(bytes);
                BinaryFormatter format = new BinaryFormatter();
                format.Binder = new UBinder();
                receiveObject = (AccountMessage)format.Deserialize(memory);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void writeAccountStr(AccountMessage sendObject)
        {
            try
            {
                MemoryStream memory = new MemoryStream();
                BinaryFormatter format = new BinaryFormatter();
                format.Serialize(memory, sendObject);
                byte[] bytes = memory.ToArray();

                bw.Write(bytes);
                bw.Flush();

            }
            catch (Exception e)
            {
                //发送失败
                throw new Exception(e.Message);
            }

        }

        public void close()
        {
            streamToServer.Close();
            tcp.Close();
            bw.Close();
            br.Close();
            state = connectState.DISCONNECTED;
        }
        private int port;
        private string serverIP;
        TcpClient tcp;
        NetworkStream streamToServer;
        private connectState state;
    }
}
