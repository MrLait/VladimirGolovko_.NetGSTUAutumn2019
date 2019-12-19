using System;
using System.Net.Sockets;
using ClientServerLib.StreamIO;

namespace ClientServerLib.Server
{
    public class ServerClient
    {
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
                        Console.WriteLine("Client № {0}: {1}", _clientId, NetworkStreamIO.GetMessage(_networkStream));
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
    }
}
