using System;
using System.Net.Sockets;
using System.Text;
using ClientServerLib.StreamIO;

namespace ClientServerLib.Client
{
    public class Client
    {
        private const int port = 8888;
        private const string address = "127.0.0.1";
        private string _name;

        public Client(string name)
        {
            _name = name;
        }

        public void LoadClient()
        {
            string userName = _name;
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream _networkStream = client.GetStream();

                while (true)
                {
                    Console.Write(userName + ": ");
                    // ввод сообщения
                    string message = Console.ReadLine();
                    // преобразуем сообщение в массив байтов

                    NetworkStreamIO.SendMessage(message, _networkStream);
                    string response = NetworkStreamIO.GetMessage(_networkStream);

                    Console.WriteLine(response);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                Console.WriteLine("client stop");
                client.Close();
            }
        }
    }
}
