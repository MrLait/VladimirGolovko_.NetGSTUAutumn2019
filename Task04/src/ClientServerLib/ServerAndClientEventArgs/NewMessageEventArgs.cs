using System;

namespace ClientServerLib.ServerAndClientEventArgs
{
    /// <summary>
    /// Base event type for input messages.
    /// </summary>
    public class NewMessageEventArgs: EventArgs
    {
        /// <summary>
        /// Input message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Constructor for <see cref="NewMessageEventArgs"/>
        /// </summary>
        /// <param name="message">Input message.</param>
        public NewMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
