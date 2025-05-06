using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
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

        public void MurdererWinsTest()
        {
            string url = "http://127.0.0.1:5500/index.html";
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Game Status", _driver.Title);

            IWebElement inputElementFirst = _driver.FindElement(By.Id("player1"));
            inputElementFirst.SendKeys("1");

            IWebElement inputElementSec = _driver.FindElement(By.Id("player2"));
            inputElementSec.SendKeys("2");

            IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement showResultElement = wait.Until(driver => driver.FindElement(By.Id("showResult")));

            string resultText = showResultElement.Text;
            Assert.AreEqual("The Murderer wins!", resultText);

        }

        [TestMethod]

        public void PlayersWinsTest() 
        {
            //_driver?.Dispose();
            IWebDriver? _driver = new FirefoxDriver(DriverDirectory);
            string url = "http://127.0.0.1:5500/index.html";
            _driver.Navigate().GoToUrl(url);
            //_driver.Navigate().Refresh();

            Assert.AreEqual("Game Status", _driver.Title);

            IWebElement inputElementFirst = _driver.FindElement(By.Id("player1"));
            inputElementFirst.SendKeys("2");

            IWebElement inputElementSec = _driver.FindElement(By.Id("player2"));
            inputElementSec.SendKeys("3");

            IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement showResultElement = wait.Until(driver => driver.FindElement(By.Id("showResult")));

            string resultText = showResultElement.Text;
            Assert.AreEqual("The two players win!", resultText);
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
