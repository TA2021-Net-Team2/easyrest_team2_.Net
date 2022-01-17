using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class AdminPageTests : BaseTest
    {
        private const string StartLoginAdmin = "steveadmin@test.com";
        private const string PasswordAdmin = "1";

        private AdminPanel _adminPanel;
        private BasePage _basePage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            Login();
            _adminPanel = new AdminPanel(_webDriver);
            _basePage = new BasePage(_webDriver);
        }

        private void Login()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginAdmin, PasswordAdmin);
        }

        [Test]
        public void Test401_AdminLogin()
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test]
        public void Test402_UserLock()
        {
            _adminPanel.LockFirstUser();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void Test403_UserUnlock()
        {
            _adminPanel.UnlockFirstUser();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void Test404_OwnerLock()
        {
            _adminPanel.LockOwner();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void Test405_OwnerUnlock()
        {
            _adminPanel.UnlockOwner();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void Test406_ModeratorLock()
        {
            _adminPanel.LockModerator();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void Test407_ModeratorUnlock()
        {
            _adminPanel.UnlockModerator();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void Test408_AddModerator()
        {
            _adminPanel.AddModerator();

            Assert.AreEqual("Austin Powers", _adminPanel.GetNameModerator());
        }
    }
}