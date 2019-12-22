using ClientServerLib.UserExceptions;
using ClientServerLib.Model;
using NUnit.Framework;

namespace ClientServerLibTests.UserExceptions
{
    [TestFixture()]
    public class ConnectionErrorTests
    {
        [TestCase("Vova", 5, "127.0.0.1", 8886)]
        public void GivenConnectionErrorTheOutIsConnectionError(string actualName, int actualNumMassages, string actualIp, int actualPort)
        {
            //Assert
            Assert.That(() => new Client(actualName, actualNumMassages, actualIp, actualPort), Throws.TypeOf<ConnectionError>());
        }

    }
}
