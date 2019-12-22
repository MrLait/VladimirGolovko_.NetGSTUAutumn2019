using System.Threading;
using ClientServerLib.Model;
using ClientServerLib.Repositories;

namespace ConsoleAppTcpClient
{
    class Program
    {
        static void Main()
        {
            Client tcpClient = new Client("Vova", 10, "127.0.0.1", 8888);
            Thread clientThread = new Thread(new ThreadStart(tcpClient.OpenStream));
            clientThread.Start();
            ServerMessageRepository messagesFromServer = new ServerMessageRepository(tcpClient);


        }
    }
}
