using ClientServerLib.Model;
using System;
using System.Collections.Generic;

namespace ClientServerLib.Repositories
{
    /// <summary>
    /// The type that is subscribed to the event of receiving a message from the server.
    /// </summary>
    public class ClientMessageRepository
    {
        /// <summary>
        /// List of messages from server.
        /// </summary>
        public List<string> Messages { get; }

        /// <summary>
        /// Constructir <see cref="ClientMessageRepository"/>
        /// </summary>
        /// <param name="serverClient"></param>
        public ClientMessageRepository(Conversation serverClient)
        {
            Messages = new List<string>();

            serverClient.NewMessage += (sender, e) =>
            {
                Console.WriteLine("Client № {0}: {1}", e.Id, e.Message);
                Messages.Add(string.Format("Client № {0}: {1}", e.Id, e.Message));
            };
        }
    }
}
