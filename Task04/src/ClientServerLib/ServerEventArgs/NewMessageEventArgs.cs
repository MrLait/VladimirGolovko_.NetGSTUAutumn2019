using System;

namespace ClientServerLib.ServerEventArgs
{
    public class NewMessageEventArgs : EventArgs
    {
        public string Message { get; }
        public int Id { get; }

        public NewMessageEventArgs(string message, int id)
        {
            Message = message;
            Id = id;
        }
    }
}
