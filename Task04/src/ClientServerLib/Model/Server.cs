using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ClientServerLib.Repositories;

namespace ClientServerLib.Model
{
    /// <summary>
    /// Server class that describes a server connections with client.
    /// </summary>
    public class Server
    {
        static TcpListener tcpListener;

        /// <summary>
        /// Server port.
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// List of client connections on the server.
        /// </summary>
        public List<Conversation> ServerClients { get; private set; }

        /// <summary>
        /// A list to store each client’s messages.
        /// </summary>
        public List<ClientMessageRepository> MessagesFromClients { get; private set; }

        /// <summary>
        /// Constructor <see cref="Server"/>
        /// </summary>
        /// <param name="port">Server port.</param>
        public Server(int port)
        {
            Port = port;
            ServerClients = new List<Conversation>();
            MessagesFromClients = new List<ClientMessageRepository>();
        }

        /// <summary>
        /// Server launch.
        /// </summary>
        public void Start()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, Port);
                tcpListener.Start();
                Console.WriteLine("Waiting for connection... ");
                int clientId = 0;

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Console.WriteLine(String.Format("Client with id: {0} connected.", clientId));

                    Conversation serverClient = new Conversation(client, this, clientId);
                    Thread listenThread = new Thread(new ThreadStart(serverClient.OpenStream));
                    listenThread.Start();
                    
                    MessagesFromClients.Add(new ClientMessageRepository(serverClient));

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

        /// <summary>
        /// Adding a new connected client to the collection.
        /// </summary>
        /// <param name="newClientOnTheServer"> A new client on the server.</param>
        internal void AddClientConnection(Conversation newClientOnTheServer)
        {
            ServerClients.Add(newClientOnTheServer);
        }

        /// <summary>
        /// Disconnecting the client from the server.
        /// </summary>
        /// <param name="newClientOnTheServer">Client on the server.</param>
        internal void ClientDisconnected(Conversation newClientOnTheServer)
        {
            if (newClientOnTheServer != null)
            {
                ServerClients.Remove(newClientOnTheServer);
            }
        }
    }
}
