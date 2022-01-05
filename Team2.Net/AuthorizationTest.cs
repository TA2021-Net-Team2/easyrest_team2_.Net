using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class AuthorizationPageTests
    {
        private IWebDriver _webDriver;

        string StartLoginOwner = "earlmorrison@test.com";
        string StartLoginClient = "kellymeza@test.com";
        string StartLoginAdmin = "steveadmin@test.com";

        string Password = "1111";
        string PasswordAdmin = "1";


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

        [Test]
        public void AuthorizationTestClient()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(StartLoginClient, Password);
        }

        [Test]
        public void AuthorizationTestAdmin()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(StartLoginAdmin, PasswordAdmin);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(1000);
            _webDriver.Quit();
        }
    }
}