using System.Net.Sockets;
using System.Text;

namespace ClientServerLib.StreamIO
{
    public static class NetworkStreamIO
    {
        public static void SendMessage(string message, NetworkStream _networkStream)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            // send messege
            _networkStream.Write(data, 0, data.Length);
        }


        public static string GetMessage(NetworkStream _networkStream)
        {
            byte[] data = new byte[256];
            StringBuilder stringBuilder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = _networkStream.Read(data, 0, data.Length);
                stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (_networkStream.DataAvailable);

            return stringBuilder.ToString();
        }
    }
}
