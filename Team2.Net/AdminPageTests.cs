using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

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

        [Test(Description = "Admin log in")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test401_AdminLogin() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=932613514
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test(Description = "Lock user")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test402_UserLock() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=1331648278
        {
            _adminPanel.LockFirstUser();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test(Description = "Unlock user")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test403_UserUnlock() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=1032936101
        {
            _adminPanel.UnlockFirstUser();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test(Description = "Lock owner")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test404_OwnerLock() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=1645371598
        {
            _adminPanel.LockOwner();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test(Description = "Unlock owner")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test405_OwnerUnlock() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=1750068393
        {
            _adminPanel.UnlockOwner();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test(Description = "Lock moderator")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test406_ModeratorLock() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=1074097320
        {
            _adminPanel.LockModerator();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }
        [Test(Description = "Unlock moderator")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test407_ModeratorUnlock() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=29976917
        {
            _adminPanel.UnlockModerator();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test(Description = "Add moderator")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test408_AddModerator() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=1552482350
        {
            _adminPanel.AddModerator();

            Assert.AreEqual("Austin Powers", _adminPanel.GetNameModerator());
        }
    }
}