namespace ClientServerLib.ServerAndClientEventArgs
{
    /// <summary>
    /// Type contains additional information about the new message to client event.
    /// </summary>
    public class NewMessageToClientEventArgs : NewMessageEventArgs
    {
        /// <summary>
        /// Constructor <see cref="NewMessageToClientEventArgs"/> 
        /// </summary>
        /// <param name="message">New message</param>
        public NewMessageToClientEventArgs(string message) : base(message)
        {
        }
    }
}
