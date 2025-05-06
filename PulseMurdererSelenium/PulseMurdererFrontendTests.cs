using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
namespace PulseMurdererSelenium
{
    [TestClass]
    public sealed class PulseMurdererFrontendTests
    {
        private static readonly string DriverDirectory = "c:\\WebDrivers";
        private static IWebDriver? _driver;

        [ClassInitialize]
        public static void setup(TestContext context)
        {
            //_driver = new EdgeDriver(DriverDirectory);
            _driver = new CromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _driver?.Dispose();
        }

        [TestMethod]

        public void TestMethod1()
        {
            string url = "http://127.0.0.1:5500/index.html";
            _driver?.Navigate().GoToUrl(url);

            Assert.AreEqual("Game Status", _driver?.Title);
        }
    }
}
