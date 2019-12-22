using ClientServerLib.Model;
using ClientServerLib.Repositories;
using NUnit.Framework;
using System.Threading;

namespace ClientServerLibTests.UserExceptions
{
    /// <summary>
    /// ServerMessageRepositoryTests type test and related classes with it.
    /// </summary>
    [TestFixture()]
    public class ServerMessageRepositoryTests
    {
        /// <summary>
        /// Testing make transliteration from rus into English
        /// </summary>
        /// <param name="actualName">Name of client.</param>
        /// <param name="actualNumMassages">Numbers of send message</param>
        /// <param name="actualIp">Server ip.</param>
        /// <param name="actualPort">Serve port</param>
        [TestCase("Vova", 5, "127.0.0.1", 8884)]
        public void GivenMakeTransliterationFromRusIntoEnglishTheOutIsStringWithTranslit(string actualName, int actualNumMassages, string actualIp, int actualPort)
        {
            //Arrange
            Server tcpServer = new Server(actualPort);
            Thread serverThread = new Thread(new ThreadStart(tcpServer.Start));
            serverThread.Start();

            Client tcpClient = new Client(actualName, actualNumMassages, actualIp, actualPort);
            ServerMessageRepository messagesFromServer = new ServerMessageRepository(tcpClient);

            tcpClient.OpenStream();
                       
            //Assert
            Assert.AreEqual("Message from server received, Translitom: soobshchenie ot servera prinyato", messagesFromServer.Messages[0]);
        }

    }
}
