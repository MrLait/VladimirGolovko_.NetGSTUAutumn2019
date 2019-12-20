using System;
using System.Net.Sockets;
using ClientServerLib.ServerEventArgs;
using ClientServerLib.StreamIO;

namespace ClientServerLib.Server
{
    
    public class ServerClient
    {
        public event EventHandler<NewMessageEventArgs> NewMessage;

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
                        string getMessage = NetworkStreamIO.GetMessage(_networkStream);

                        GetNewMessage(getMessage, _clientId);

                        NetworkStreamIO.SendMessage("Message from server received", _networkStream);
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

        protected void OnNewMessage(NewMessageEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }

        public void GetNewMessage(string message, int clientId)
        {
            NewMessageEventArgs e = new NewMessageEventArgs(message, clientId);
            OnNewMessage(e);
        }

    }
}
