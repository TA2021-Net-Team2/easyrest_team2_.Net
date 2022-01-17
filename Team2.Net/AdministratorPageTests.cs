using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class AdministratorPageTests : BaseTest
    {
        private const string StartLoginAdministrator = "eringonzales@test.com";
        private const string PasswordAdministrator = "1";

        private AdministratorPanel _administratorPanel;
        private BasePage _basePage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            AdministratorLogin();
            _administratorPanel = new AdministratorPanel(_webDriver);
            _basePage = new BasePage(_webDriver);
        }

        private void AdministratorLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginAdministrator, PasswordAdministrator);
        }

        [Test]
        public void Test501_AdministratorLogin()
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test]
        public void Test502_Acception_func()
        {
            _administratorPanel.Acception_func();
            Assert.True(_administratorPanel.GetAcceptionStatusForFirstUser());
        }

        [Test]
        public void Test503_Assign_waiter_func()
        {
            _administratorPanel.Assign_waiter_func();
            Assert.True(_administratorPanel.GetAssignStatusForFirstUser());
        }

        [Test]
        public void Test504_Assign_waiter_func()
        {
            _administratorPanel.Watch_info_waiter();
            Assert.False(_administratorPanel.GetWaiterAssignedPanelBack());
        }

        [Test]
        public void Test505_Waiters_tab_info()
        {
            _administratorPanel.Waiters_tab_info();
            Assert.False(_administratorPanel.GetWaiterAssignedPanelBack());
        }

        [Test]
        public void Test506_Error()
        {
            _administratorPanel.Error();
            Assert.AreEqual("Pls pick waiter", _administratorPanel.GetCheckErrorStatusForFirstUser());
        }
    }
}