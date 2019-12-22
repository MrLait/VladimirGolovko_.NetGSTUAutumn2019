using ClientServerLib.UserExceptions;
using ClientServerLib.Model;
using NUnit.Framework;

namespace ClientServerLibTests.UserExceptions
{
    /// <summary>
    /// ConnectionErrorTests type test and related classes with it.
    /// </summary>
    [TestFixture()]
    public class ConnectionErrorTests
    {
        /// <summary>
        /// Testing exceprion ConnectionError
        /// </summary>
        /// <param name="actualName">Name of client.</param>
        /// <param name="actualNumMassages">Numbers of send message</param>
        /// <param name="actualIp">Server ip.</param>
        /// <param name="actualPort">Serve port</param>
        [TestCase("Vova", 5, "127.0.0.1", 8886)]
        public void GivenConnectionErrorTheOutIsConnectionError(string actualName, int actualNumMassages, string actualIp, int actualPort)
        {
            //Assert
            Assert.That(() => new Client(actualName, actualNumMassages, actualIp, actualPort), Throws.TypeOf<ConnectionError>());
        }

    }
}
