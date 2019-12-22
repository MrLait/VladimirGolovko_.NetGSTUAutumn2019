using System.Net.Sockets;
using System.Text;

namespace ClientServerLib.StreamIO
{
    /// <summary>
    /// Type for network messaging.
    /// </summary>
    public static class NetworkStreamIO
    {
        /// <summary>
        /// Write messages.
        /// </summary>
        /// <param name="message"> Output messages. </param>
        /// <param name="_networkStream"> Network stream to write messages. </param>
        public static void SendMessage(string message, NetworkStream _networkStream)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            
            _networkStream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Get messages.
        /// </summary>
        /// <param name="_networkStream">Network stream to read messages</param>
        /// <returns>Input messages.</returns>
        public static string GetMessage(NetworkStream _networkStream)
        {
            byte[] data = new byte[256];
            StringBuilder stringBuilder = new StringBuilder();

            do
            {
                int bytes = _networkStream.Read(data, 0, data.Length);
                stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (_networkStream.DataAvailable);

            return stringBuilder.ToString();
        }
    }
}
