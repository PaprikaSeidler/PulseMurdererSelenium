using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
namespace PulseMurdererSelenium
{
    [TestClass]
    public sealed class PulseMurdererFrontendTests
    {
        private static readonly string DriverDirectory = "c:\\WebDrivers";
        //private static readonly string DriverDirectory = "C:\\web-drivers"; //Paprika
        private static IWebDriver? _driver;

        [ClassInitialize]
        public static void setup(TestContext context)
        {
            //_driver = new EdgeDriver(DriverDirectory);
            _driver = new ChromeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
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

        //PlayerPage
        [TestMethod]
        public void TestPlayerPageTitle()
        {
            string url = "http://127.0.0.1:5500/playerPage.html";
            _driver?.Navigate().GoToUrl(url);
            Assert.AreEqual("Player", _driver?.Title);
        }

        [TestMethod]
        public void TestPlayerVoteButtons()
        {
            string url = "http://127.0.0.1:5500/playerPage.html";
            _driver?.Navigate().GoToUrl(url);

            var voterButton = _driver?.FindElements(By.Id("voterButton"));
            voterButton[1].Click();
            Assert.IsTrue(voterButton[1].GetAttribute("class").Contains("btn-success"));
            Assert.AreEqual("John", voterButton[1].Text);

            var voterButton2 = _driver?.FindElements(By.Id("voterButton"));
            Assert.IsTrue(voterButton[0].GetAttribute("class").Contains("btn-primary"));
        }
    }
}
