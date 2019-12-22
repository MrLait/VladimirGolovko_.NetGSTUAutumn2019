using ClientServerLib.Model;
using NUnit.Framework;
using System.Threading;

namespace ClientServerLibTests.Model
{
    /// <summary>
    /// Server type test and related classes with it.
    /// </summary>
    [TestFixture()]
    public class ServerTest
    {
        /// <summary>
        /// Testing client connections to the server.
        /// </summary>
        /// <param name="actualNameOne"> Name of clients</param>
        /// <param name="actualNumMassages">Numbers of send message</param>
        /// <param name="actualIp">Server ip.</param>
        /// <param name="actualPort">Serve port</param>
        [TestCase("Vova", 5, "127.0.0.1", 8895)]
        public void GivenServerWhenInitInstancTheOutIsTwoClients(string actualNameOne, int actualNumMassages, string actualIp, int actualPort)
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
