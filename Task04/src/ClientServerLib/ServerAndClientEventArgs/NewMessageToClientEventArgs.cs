using System;

namespace ClientServerLib.ServerAndClientEventArgs
{
    public class NewMessageToClientEventArgs : NewMessageEventArgs
    {
        public NewMessageToClientEventArgs(string message) :base(message) 
        {
        }
    }
}
