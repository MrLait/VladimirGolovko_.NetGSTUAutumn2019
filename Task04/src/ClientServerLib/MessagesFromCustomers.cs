using ClientServerLib.Server;
using ClientServerLib.ServerEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //string clientMessage = string.Format();
                messages.Add(string.Format("Client № {0}: {1}", e.Id, e.Message));
            };
        }

    }
}
