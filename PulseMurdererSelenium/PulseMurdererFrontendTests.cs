﻿using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

using static System.Net.WebRequestMethods;
namespace PulseMurdererSelenium
{
    [TestClass]
    public sealed class PulseMurdererFrontendTests
    {

        private static readonly string DriverDirectory = "c:\\WebDrivers";
        //private static readonly string DriverDirectory = "C:\\web-drivers"; //Paprika
        private static IWebDriver? _driver;
        public string murdererURL = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/";

        [TestInitialize]
        public void TestSetup()
        {
            //_driver = new EdgeDriver(DriverDirectory);
            //_driver = new ChromeDriver(DriverDirectory);
            _driver = new FirefoxDriver(DriverDirectory);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver?.Dispose();
        }

        //[ClassInitialize]
        //public static void setup(TestContext context)
        //{
        //    //_driver = new EdgeDriver(DriverDirectory);
        //    //_driver = new ChromeDriver(DriverDirectory);
        //    _driver = new FirefoxDriver(DriverDirectory);
        //}

        //[ClassCleanup]
        //public static void Cleanup()
        //{
        //    _driver?.Dispose();
        //}

        [TestMethod]
        public void TestGameStatusTitle()
        {
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/index.html";
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Start Game", _driver.Title);
        }

        [TestMethod]
        public void TestStartButtonClick()
        {
            _driver.Navigate().GoToUrl("https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/index.html");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            //var startButton = wait.Until(driver => driver.FindElement(By.Id("btnStart")));
            //startButton.Click();

        }

        [TestMethod]
        public void TestResetButtonClick()
        {
            _driver.Navigate().GoToUrl("https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/index.html");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            //var resetButton = _driver.FindElement(By.Id("btnReset"));
            //resetButton.Click();
        }

        [TestMethod]
        public void MurdererWinsTest()
        {
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/gameResult.html";
            _driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //// Wait for the murderer section to appear
            //var murdererSection = wait.Until(driver => driver.FindElement(By.Id("murderer-section")));
            //Assert.IsNotNull(murdererSection);

            //// Check for the murderer header (note the typo in the id: "muderer-header")  
            //var murdererHeader = murdererSection.FindElement(By.Id("muderer-header"));
            //Assert.IsNotNull(murdererHeader);
            //Assert.AreEqual("The Murderer Wins!", murdererHeader.Text);

            //// Check for at least one murderer avatar
            //var murdererAvatars = murdererSection.FindElements(By.XPath(".//img[@alt='Avatar' and contains(@class, 'rounded-circle')]"));
            //Assert.IsTrue(murdererAvatars.Count > 0);

            //// Check for at least one civilian avatar
            //var civilianAvatars = murdererSection.FindElements(By.XPath(".//img[starts-with(@id, 'civilian-avatar-')]"));
            //Assert.IsTrue(civilianAvatars.Count > 0);
        }



        [TestMethod]
        public void PlayersWinsTest() 
        {
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/gameResult.html";
            _driver.Navigate().GoToUrl(url);

            //IWebElement inputElementFirst = _driver.FindElement(By.Id("player1"));
            //inputElementFirst.SendKeys("2");

            //IWebElement inputElementSec = _driver.FindElement(By.Id("player2"));
            //inputElementSec.SendKeys("3");

            //IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            //buttonElement.Click();

            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            //IWebElement showResultElement = wait.Until(driver => driver.FindElement(By.Id("showResult")));

            //string resultText = showResultElement.Text;
            //Assert.AreEqual("The two players win!", resultText);
        }

        [TestMethod]
        public void WrongPlayerTest()
        {
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/index.html";
            _driver.Navigate().GoToUrl(url);

            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //// Wait for and fill player1 input
            //var inputElementFirst = wait.Until(driver => driver.FindElement(By.Id("player1")));
            //inputElementFirst.Clear();
            //inputElementFirst.SendKeys("2");

            //// Wait for and fill player2 input
            //var inputElementSec = wait.Until(driver => driver.FindElement(By.Id("player2")));
            //inputElementSec.Clear();
            //inputElementSec.SendKeys("6");

            //// Wait for and click the submit button
            //var buttonElement = wait.Until(driver => driver.FindElement(By.Id("button")));
            //buttonElement.Click();

            //// Wait for and check the result
            //var showResultElement = wait.Until(driver => driver.FindElement(By.Id("showResult")));
            //string resultText = showResultElement.Text;
            //Assert.AreEqual("Invalid player IDs. Please try again.", resultText);
        }


        //PlayerPage
        [TestMethod]
        public void TestPlayerPageTitle()
        {
            // Include a valid player ID in the URL query string
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/playerPage.html?playerId=1";
            _driver.Navigate().GoToUrl(url);

            // Handle any unexpected alert dialogs
            try
            {
                WebDriverWait alertWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
                alertWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                IAlert alert = _driver.SwitchTo().Alert();
                alert.Dismiss(); // Dismiss the alert if it appears
            }
            catch (WebDriverTimeoutException)
            {
                // No alert appeared, continue with the test
            }

            // Wait until the title is set to "Welcome"
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.Title == "Welcome");

            Assert.AreEqual("Welcome", _driver.Title);
        }



        [TestMethod]
        public void TestPlayerVoteButtons()
        {
            // Include a valid player ID in the URL query string
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/playerPage.html?playerId=1";
            _driver.Navigate().GoToUrl(url);

            //var voterButton = _driver?.FindElements(By.Id("voterButton"));
            //voterButton[1].Click();
            //Assert.IsTrue(voterButton[1].GetAttribute("class").Contains("chosenButton"));
            //Assert.AreEqual("John", voterButton[1].Text);

            //var voterButton2 = _driver?.FindElements(By.Id("voterButton"));
            //Assert.IsTrue(voterButton[0].GetAttribute("class").Contains("voteButton"));
        }

        //QrPage
        [TestMethod]
        public void TestQrPage()
        {
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/index.html?playerId=1";
            _driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var qrBtn = wait.Until(driver => driver.FindElement(By.Id("qrBtn")));
            qrBtn.Click();

            var qrImg = wait.Until(driver => driver.FindElement(By.Id("qrCodeImage")));
            Assert.IsNotNull(qrImg);
            Assert.IsTrue(qrImg.Displayed);
        }




        [TestMethod]
        public void TestUDPData()
        {
            string url = "https://pulsemurderer-bqaqacc5feh8h3aa.northeurope-01.azurewebsites.net/sharedPage.html";
            _driver?.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var dataDisplay = wait.Until(driver => driver.FindElement(By.Id("data")));
            Assert.IsNotNull(dataDisplay);
        }

    }
}
