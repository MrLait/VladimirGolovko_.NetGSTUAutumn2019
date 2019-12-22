using System.Threading;
using ClientServerLib.Model;

namespace ConsoleAppTcpServer
{
    class Program
    {
        static void Main()
        {
            Server tcpServer = new Server(8888);
            Thread serverThread = new Thread(new ThreadStart(tcpServer.Start));
            serverThread.Start();
        }
    }
}
