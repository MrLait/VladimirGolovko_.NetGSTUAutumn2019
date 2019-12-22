using ClientServerLib.Model;
using NUnit.Framework;
using System;
using System.Threading;

namespace ClientServerLibTests.Model
{
    [TestFixture()]
    public class ClientTest
    {
        [TestCase()]
        public void GivenOpenStreamWhenServerIsStartedTheOutIsConnectedTrue()
        {
            //Arrange
            Server tcpServer = new Server(8889);
            Thread serverThread = new Thread(new ThreadStart(tcpServer.Start));
            serverThread.Start();

            Client tcpClient = new Client("Client", 1, "127.0.0.1", 8889);
            Thread clientThread = new Thread(new ThreadStart(tcpClient.OpenStream));
            clientThread.Start();

            //Assert
            Assert.AreEqual(true, tcpClient.TcpClient.Connected);
        }


        [TestCase(5, 8880)]
        public void GivenOpenStreamWhenSendNMessageTheOutIseNMessage(int actualNumMassages, int actualPort)
        {
            //Arrange
            Server tcpServer = new Server(actualPort);
            Thread serverThread = new Thread(new ThreadStart(tcpServer.Start));
            serverThread.Start();

            Client tcpClient = new Client("Vova", actualNumMassages, "127.0.0.1", actualPort);
            
            //Act
            tcpClient.OpenStream();

            //Assert
            Assert.AreEqual(tcpServer.MessagesFromClients[0].Messages.Count, actualNumMassages + 1);
        }

        [TestCase("Vova", 5, "127.0.0.1", 8887)]
        public void GivenClientWhenInitInstancTheOutString(string actualName, int actualNumMassages, string actualIp, int actualPort)
        {
            //Arrange
            Server tcpServer = new Server(8887);
            Thread serverThread = new Thread(new ThreadStart(tcpServer.Start));
            serverThread.Start();

            Client tcpClient = new Client(actualName, actualNumMassages, actualIp, actualPort);

            //Assert
            Assert.AreEqual("Vova 5 127.0.0.1 8887", string.Format("{0} {1} {2} {3}", actualName, actualNumMassages, actualIp, actualPort));
        }
    }
}
