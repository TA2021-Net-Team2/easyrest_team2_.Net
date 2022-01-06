using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class OwnerPageTests
    {
        private IWebDriver _webDriver;

        string StartLoginOwner = "earlmorrison@test.com";
        string Password = "1111";

        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://localhost:3000/");
            _webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void AuthorizationTestOwner()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(StartLoginOwner, Password);
        }

/*        [Test]
        public void UserLockTest()
        {
            AuthorizationTestOwner();


        }*/


        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(1000);
            _webDriver.Quit();
        }
    }
}