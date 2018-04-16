using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Test
{
    class Server
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static Dictionary<string, ClientHandler> dSockets = new Dictionary<string, ClientHandler>();
        static Socket sck;
        static Socket acc;       
        static void Connection()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(IPAddress.Parse("192.168.42.125"), 89));
            sck.Listen(2);
            Console.WriteLine("Server listing.........");
        }
        /// <summary>
        /// this opeartion method is for server handling the connected clients
        /// </summary>
        static void Operation()
        {
            while (true)
            {
                // Accept the incoming request
                acc = sck.Accept();
                try
                {
                    byte[] a = new byte[255];
                    int rec = acc.Receive(a, 0, a.Length, 0);
                    Array.Resize(ref a, rec);
                    string name = Encoding.Default.GetString(a);
                    Console.WriteLine(name + " Joined.....");
                    byte[] send = Encoding.Default.GetBytes(name);
                    acc.Send(send, 0, send.Length, 0);
                    byte[] Buf1 = new byte[255];
                    int rec1 = acc.Receive(Buf1, 0, Buf1.Length, 0);
                    Array.Resize(ref Buf1, rec1);
                    string connect = Encoding.Default.GetString(Buf1);

                    ClientHandler client = new ClientHandler(acc, name, connect, dSockets);
                    dSockets.Add(name, client);

                    Thread thread1 = new Thread(client.Run);
                    Thread thread2 = new Thread(client.Send);
                    thread1.Start();
                    thread2.Start();
                }
                catch (Exception e)
                {
                    log.Info(e.Message);
                }
            }
        }
        /// <summary>
        /// this is main method is calling connection and operation methods.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            Connection();
            Operation();
            Console.ReadLine();
        }
    }
}

