using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerLib.ServerAndClientEventArgs
{
    public class NewMessageToServerEventArgs : NewMessageEventArgs
    {
        public int Id { get; }

        public NewMessageToServerEventArgs(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
