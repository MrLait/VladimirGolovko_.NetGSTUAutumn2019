using ClientServerLib.Model;
using NUnit.Framework;
using System.Threading;

namespace ClientServerLibTests.Model
{
    [TestFixture()]
    public class ServerTest
    {
        [TestCase("Vova", "Dima", 5, "127.0.0.1", 8895)]
        public void GivenServerWhenInitInstancTheOutIsTwoClients(string actualNameOne, string actualNameTwo, int actualNumMassages, string actualIp, int actualPort)
        {
            //Arrange
            Server tcpServer = new Server(actualPort);
            Thread serverThread = new Thread(new ThreadStart(tcpServer.Start));
            serverThread.Start();

            Client tcpClientOne = new Client(actualNameOne, actualNumMassages, actualIp, actualPort);
            Thread clientThreadOne = new Thread(new ThreadStart(tcpClientOne.OpenStream));
            clientThreadOne.Start();

            tcpClientOne.OpenStream();

            //Assert
            Assert.AreEqual(tcpServer.ServerClients.Count, 1);
        }
    }
}
