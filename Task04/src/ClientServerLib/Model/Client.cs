using System;
using System.Net.Sockets;
using ClientServerLib.ServerAndClientEventArgs;
using ClientServerLib.StreamIO;
using ClientServerLib.UserExceptions;

namespace ClientServerLib.Model
{
    /// <summary>
    /// Client class that describes a client connections.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Host ip address.
        /// </summary>
        public string IpAddress { get; private set; }

        /// <summary>
        /// Host port.
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Tcp client for to connect to the server.
        /// </summary>
        public TcpClient TcpClient { get; private set; }

        /// <summary>
        /// Through this object, you can send messages to the server or, conversely, receive data from the server.
        /// </summary>
        public NetworkStream NetworkStream { get; private set; }

        /// <summary>
        /// Event to track new messages.
        /// </summary>
        public event EventHandler<NewMessageToClientEventArgs> NewMessage;

        /// <summary>
        /// The number of messages per connection to the server.
        /// </summary>
        public int NumOfMessages { get; set; }

        /// <summary>
        /// Sending message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Constructor <see cref="Client"/>
        /// </summary>
        /// <param name="name">Client name.</param>
        /// <param name="numOfMessages">The number of messages per connection to the server.</param>
        /// <param name="ipAddress">Host ip address.</param>
        /// <param name="port">Host port.</param>
        public Client(string name, int numOfMessages, string ipAddress, int port)
        {
            Name = name;
            NumOfMessages = numOfMessages;
            Port = port;
            IpAddress = ipAddress;

            try
            {
                TcpClient = new TcpClient(IpAddress, Port);
            }
            catch (SocketException)
            {
                throw new ConnectionError("Connection Error");
            }
        }

        /// <summary>
        /// Method for exchanging messages with the server.
        /// </summary>
        public void OpenStream()
        {
            int messageCounter = default;

            try
            {
                NetworkStream = TcpClient.GetStream();
                string message = string.Empty;
                while (true)
                {
                    message = string.Format("Client name: {0}; Client message: {1}", Name, Message);

                    NetworkStreamIO.SendMessage(message, NetworkStream);
                    string gettingMessage = NetworkStreamIO.GetMessage(NetworkStream);

                    GetNewMessage(gettingMessage);
                    messageCounter++;

                    if (messageCounter == NumOfMessages )
                    {
                        Console.WriteLine("Number of messages reached the limit " + NumOfMessages);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Client stop");
                if (TcpClient != null)
                    TcpClient.Close();
            }
        }

        /// <summary>
        /// Used to synchronously call the methods supported by the delegate object.
        /// </summary>
        /// <param name="newMessageToClientEventArgs"> Type to receive a message when an event occurs. </param>
        protected void OnNewMessage(NewMessageToClientEventArgs newMessageToClientEventArgs)
        {
            NewMessage?.Invoke(this, newMessageToClientEventArgs);
        }

        /// <summary>
        /// Method for notifying receipt of a new message.
        /// </summary>
        /// <param name="message">New message.</param>
        public void GetNewMessage(string message)
        {
            NewMessageToClientEventArgs e = new NewMessageToClientEventArgs(message);
            OnNewMessage(e);
        }
    }
}
