using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
namespace Test
{
    class ClientHandler
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string name;
        Socket s;
        bool loggedin;
        string[] str;
        static ClientHandler kk;
        Dictionary<string, ClientHandler> dSockets;
        public ClientHandler(Socket s, string name, string con, Dictionary<string, ClientHandler> dic)
        {
            this.name = name;
            this.s = s;
            this.loggedin = true;
            dSockets = dic;
            this.str = con.Split('/');
        }
        /// <summary>
        /// this method is for handling the clients
        /// and handling the masseges to particular clients
        /// </summary>
        public void Run()
        {
            string received;
            while (true)
            {
                try
                {
                    byte[] Buffer = new byte[255];
                    int rec = s.Receive(Buffer, 0, Buffer.Length, 0);
                    Array.Resize(ref Buffer, rec);
                    received = Encoding.Default.GetString(Buffer);
                    Console.WriteLine(received);
                    string[] st = received.Split('#');
                    string recipient = st[0];
                    string MsgToSend = st[1];
                    if (MsgToSend.Equals("logout"))
                    {
                        dSockets.Remove(recipient);
                        this.loggedin = false;
                        this.s.Close();
                        break;
                    }
                    foreach (KeyValuePair<string, ClientHandler> val in dSockets)
                    {
                        ClientHandler mc = (ClientHandler)val.Value;

                        if (mc.name.Equals(recipient))
                        {
                            kk = mc;
                        }
                        for (int i = 0; i < kk.str.Length; i++)
                        {

                            if (!(mc.name.Equals(recipient)) && mc.loggedin == true && mc.name.Equals(kk.str[i]))
                            {
                                byte[] sData = Encoding.Default.GetBytes(this.name + " : " + MsgToSend);
                                mc.s.Send(sData, 0, sData.Length, 0);
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                    log.Info(e.Message);
                }
            }
        }
        public void Send()
        {
            if (s != null)
            {
                while (true)
                {
                    string msg = Console.ReadLine();
                    foreach (KeyValuePair<string, ClientHandler> val in dSockets)
                    {
                        ClientHandler mc = (ClientHandler)val.Value;
                        byte[] sData = Encoding.Default.GetBytes("Server : " + msg);
                        mc.s.Send(sData, 0, sData.Length, 0);
                    }
                }
            }
        }
    }
}