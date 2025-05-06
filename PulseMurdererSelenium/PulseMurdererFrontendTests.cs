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
        private static IWebDriver? _driver;

        [ClassInitialize]
        public static void setup(TestContext context)
        {
            //_driver = new EdgeDriver(DriverDirectory);
            //_driver = new ChromeDriver(DriverDirectory);
            _driver = new FirefoxDriver(DriverDirectory);
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

            IWebElement inputElementFirst = _driver.FindElement(By.Id("player1"));
            inputElementFirst.SendKeys("1");

            IWebElement inputElementSec = _driver.FindElement(By.Id("player2"));
            inputElementSec.SendKeys("2");

            IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            buttonElement.Click();

            // Wait for the result element to be updated
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement showResultElement = wait.Until(driver => driver.FindElement(By.Id("showResult")));


            // Verify the result text
            string resultText = showResultElement.Text;
            Assert.AreEqual("The Murderer wins!", resultText);
        }
    }
}
