using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class AdminPageTests
    {
        private IWebDriver _webDriver;

        string StartLoginAdmin = "steveadmin@test.com";
        string PasswordAdmin = "1";

        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://localhost:3000/");
            _webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void AuthorizationTestAdmin()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(StartLoginAdmin, PasswordAdmin);
        }

        [Test]
        public void UserLockTest()
        {
            AuthorizationTestAdmin();


            var adminPanel = new AdminPanelPageObject(_webDriver);
            adminPanel
                .LockUser();

        }

        [Test]
        public void UserUnlockTest()
        {
            AuthorizationTestAdmin();

            var adminPanel = new AdminPanelPageObject(_webDriver);
            adminPanel
                .UnlockUser();
        }

        [Test]
        public void OwnerLockTest()
        {
            AuthorizationTestAdmin();

            var adminPanel = new AdminPanelPageObject(_webDriver);
            adminPanel
                .LockOwner();
        }

        [Test]
        public void OwnerUnlockTest()
        {
            AuthorizationTestAdmin();

            var adminPanel = new AdminPanelPageObject(_webDriver);
            adminPanel
                .UnlockOwner();
        }

        [Test]
        public void ModeratorLockTest()
        {
            AuthorizationTestAdmin();

            var adminPanel = new AdminPanelPageObject(_webDriver);
            adminPanel
                .LockModerator();
        }

        [Test]
        public void ModeratorUnlockTest()
        {
            AuthorizationTestAdmin();

            var adminPanel = new AdminPanelPageObject(_webDriver);
            adminPanel
                .UnlockModerator();
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(1000);
            _webDriver.Quit();
        }
    }
}