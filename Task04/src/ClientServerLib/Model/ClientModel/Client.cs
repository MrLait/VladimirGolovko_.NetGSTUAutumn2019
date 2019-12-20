using System;
using System.Net.Sockets;
using ClientServerLib.ServerAndClientEventArgs;
using ClientServerLib.StreamIO;

namespace ClientServerLib.ClientModel
{
    public class Client
    {
        private const int port = 8888;
        private const string address = "127.0.0.1";
        private string _name;

        public event EventHandler<NewMessageToClientEventArgs> NewMessage;

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
                    string gettingMessage = NetworkStreamIO.GetMessage(_networkStream);

                    GetNewMessage(gettingMessage);


                    //Console.WriteLine(gettingMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Client stop");
                client.Close();
            }
        }

        protected void OnNewMessage(NewMessageToClientEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }

        public void GetNewMessage(string message)
        {
            NewMessageToClientEventArgs e = new NewMessageToClientEventArgs(message);
            OnNewMessage(e);
        }

    }
}
