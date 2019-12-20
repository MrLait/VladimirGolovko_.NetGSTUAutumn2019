using ClientServerLib.ServerModel;
using System;
using System.Collections.Generic;

namespace ClientServerLib
{
    public class MessagesFromCustomers
    {
        private readonly List<string> messages = new List<string>();

        public List<string> Messages { get { return messages; } }

        public MessagesFromCustomers(ServerClient serverClient)
        {
            serverClient.NewMessage += (sender, e) =>
            {
                Console.WriteLine("Faxing mail message:");
                Console.WriteLine("Client № {0}: {1}", e.Id, e.Message);
                messages.Add(string.Format("Client № {0}: {1}", e.Id, e.Message));
            };
        }
    }
}
