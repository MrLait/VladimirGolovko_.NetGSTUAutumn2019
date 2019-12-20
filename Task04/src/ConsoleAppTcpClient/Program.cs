using System.Threading;

using ClientServerLib.ClientModel;
using ClientServerLib;
namespace ConsoleAppTcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client tcpClient1 = new Client("Client");
            Thread clientThread1 = new Thread(new ThreadStart(tcpClient1.LoadClient));
            clientThread1.Start();
            MessagesFromServer messagesFromServer = new MessagesFromServer(tcpClient1); 


        }
    }
}
