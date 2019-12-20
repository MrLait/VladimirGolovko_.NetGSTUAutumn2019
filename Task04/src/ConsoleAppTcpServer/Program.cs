using System.Threading;
using ClientServerLib.ServerModel;

namespace ConsoleAppTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server tcpServer = new Server();
            Thread serverThread = new Thread(new ThreadStart(tcpServer.Start));
            serverThread.Start();
        }
    }
}
