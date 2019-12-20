using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServerLib.Server
{
    public class Server
    {
        const int port = 8888;
        static TcpListener tcpListener;
        private List<ServerClient> _serverClients = new List<ServerClient>() ;

        private List<MessagesFromCustomers> messagesFromCustomers = new List<MessagesFromCustomers>();

        public void Start()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                Console.WriteLine("Waiting for connection... ");
                int clientId = 0;
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();

                    ServerClient serverClient = new ServerClient(client, this, clientId);
                    Thread listenThread = new Thread(new ThreadStart(serverClient.OpenClientStream));
                    listenThread.Start();
                    
                    messagesFromCustomers.Add(new MessagesFromCustomers(serverClient));

                    clientId++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (tcpListener != null)
                { 
                    Console.WriteLine("Server stop");
                    tcpListener.Stop();
                }
            }
        }

        internal void AddClientConnection(ServerClient serverClient)
        {
            _serverClients.Add(serverClient);
        }
        internal void ClientDisconnected(ServerClient serverClient)
        {
            if (serverClient != null)
            {
                _serverClients.Remove(serverClient);
            }
        }
    }
}
