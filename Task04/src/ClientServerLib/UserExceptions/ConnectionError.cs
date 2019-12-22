using System;

namespace ClientServerLib.UserExceptions
{
    /// <summary>
    /// Type with user ConnectionError.
    /// </summary>
    public class ConnectionError : Exception
    {
        /// <summary>
        /// ConnectionError constructor.
        /// </summary>
        /// <param name="message">ConnectionError message.</param>
        public ConnectionError(string message) : base(message) { }
    }
}
