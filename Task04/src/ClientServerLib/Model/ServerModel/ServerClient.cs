using System;
using System.Net.Sockets;
using ClientServerLib.ServerAndClientEventArgs;
using ClientServerLib.StreamIO;

namespace ClientServerLib.ServerModel
{
    
    public class ServerClient
    {
        public event EventHandler<NewMessageToServerEventArgs> NewMessage;

        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private int _clientId;
        private Server _server;

        public ServerClient(TcpClient tcpClient, Server server, int clientId)
        {
            _tcpClient = tcpClient;
            server.AddClientConnection(this);
            _clientId = clientId;
            _server = server;
        }

        public void OpenClientStream()
        {
            try
            {
                _networkStream = _tcpClient.GetStream();

                while (true)
                {
                    try
                    {
                        string gettingMessage = NetworkStreamIO.GetMessage(_networkStream);

                        GetNewMessage(gettingMessage, _clientId);

                        NetworkStreamIO.SendMessage("Message from server received, Транслитом: сообщение от сервера принято", _networkStream);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Client with id: " + _clientId + " disconected");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _server.ClientDisconnected(this);

                if (_networkStream != null)
                    _networkStream.Close();

                if (_tcpClient != null)
                    _tcpClient.Close();
            }
        }

        protected void OnNewMessage(NewMessageToServerEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }

        public void GetNewMessage(string message, int clientId)
        {
            NewMessageToServerEventArgs e = new NewMessageToServerEventArgs(message, clientId);
            OnNewMessage(e);
        }

    }
}
