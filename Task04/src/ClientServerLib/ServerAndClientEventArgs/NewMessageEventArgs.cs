using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerLib.ServerAndClientEventArgs
{
    public class NewMessageEventArgs: EventArgs
    {
        public string Message { get; }

        public NewMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
