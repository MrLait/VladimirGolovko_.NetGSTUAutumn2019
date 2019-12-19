using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTcpServer
{
    public class Server
    {
        const int port = 8888;

        public void Start()
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();

                while (true)
                {
                    Console.WriteLine("Ожидание подключений... ");
                    // get input connection
                    TcpClient client = server.AcceptTcpClient();

                    while (true)
                    {
                        byte[] data = new byte[256];
                        StringBuilder response = new StringBuilder();
                        // get network stream for read and write
                        NetworkStream stream = client.GetStream();
                        do
                        {
                            int bytes = stream.Read(data, 0, data.Length);
                            response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (stream.DataAvailable); 
                                               
                        Console.WriteLine(response.ToString());

                        data = Encoding.Unicode.GetBytes("Message from server received");
                        // send messege
                        stream.Write(data, 0, data.Length);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                { 
                    Console.WriteLine("server stop");
                    server.Stop();
                }
            }
        }
    }



    //class Program2
    //{
    //    static ServerObject server; // сервер
    //    static Thread listenThread; // потока для прослушивания
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            server = new ServerObject();
    //            listenThread = new Thread(new ThreadStart(server.Listen));
    //            listenThread.Start(); //старт потока
    //        }
    //        catch (Exception ex)
    //        {
    //            server.Disconnect();
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //}

}
