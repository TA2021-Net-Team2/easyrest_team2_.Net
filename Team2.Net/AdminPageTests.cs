﻿using NUnit.Framework;
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

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            AdminLogin();
            _adminPanel = new AdminPanel(_webDriver);
        }

        private void AdminLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginAdmin, PasswordAdmin);
        }

        [Test]
        public void UserLockTest()
        {
            _adminPanel.LockFirstUser();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void UserUnlockTest()
        {
            _adminPanel.UnlockFirstUser();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void OwnerLockTest()
        {
            _adminPanel.LockOwner();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void OwnerUnlockTest()
        {
            _adminPanel.UnlockOwner();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void ModeratorLockTest()
        {
            _adminPanel.LockModerator();

            Assert.AreEqual("Banned", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void ModeratorUnlockTest()
        {
            _adminPanel.UnlockModerator();

            Assert.AreEqual("Active", _adminPanel.GetActivityStatusForFirstUser());
        }

        [Test]
        public void AddModeratorTest()
        {
            _adminPanel.AddModerator();

        }
    }
}