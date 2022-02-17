using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

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

        [Test(Description = "Administrator log in")]
        [AllureTag]
        [AllureOwner("Yatsyna")]
        public void Test501_AdministratorLogin() // https://docs.google.com/spreadsheets/d/1ffSUVY0xBc8bmnmwUkEq01rlilnv7Mxl6TLeXR5bQb8/edit#gid=0
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test(Description = "Acception func")]
        [AllureTag]
        [AllureOwner("Yatsyna")]
        public void Test502_Acception_func() // https://docs.google.com/spreadsheets/d/1ffSUVY0xBc8bmnmwUkEq01rlilnv7Mxl6TLeXR5bQb8/edit#gid=1073237504
        {
            _administratorPanel.Acception_func();
            Assert.True(_administratorPanel.GetAcceptionStatusForFirstUser());
        }

        [Test(Description = "Assign waiter")]
        [AllureTag]
        [AllureOwner("Yatsyna")]
        public void Test503_Assign_waiter_func() // https://docs.google.com/spreadsheets/d/1ffSUVY0xBc8bmnmwUkEq01rlilnv7Mxl6TLeXR5bQb8/edit#gid=633920834
        {
            _administratorPanel.Assign_waiter_func();
            Assert.True(_administratorPanel.GetAssignStatusForFirstUser());
        }

        [Test(Description = "Assign waiter func")]
        [AllureTag]
        [AllureOwner("Yatsyna")]
        public void Test504_Assign_waiter_func() // https://docs.google.com/spreadsheets/d/1ffSUVY0xBc8bmnmwUkEq01rlilnv7Mxl6TLeXR5bQb8/edit#gid=837467035
        {
            _administratorPanel.Watch_info_waiter();
            Assert.False(_administratorPanel.GetWaiterAssignedPanelBack());
        }

        [Test(Description = "Waiter info")]
        [AllureTag]
        [AllureOwner("Yatsyna")]
        public void Test505_Waiters_tab_info() // https://docs.google.com/spreadsheets/d/1ffSUVY0xBc8bmnmwUkEq01rlilnv7Mxl6TLeXR5bQb8/edit#gid=1245154818
        {
            _administratorPanel.Waiters_tab_info();
            Assert.False(_administratorPanel.GetWaiterAssignedPanelBack());
        }

        [Test(Description = "Error")]
        [AllureTag]
        [AllureOwner("Yatsyna")]
        public void Test506_Error() // https://docs.google.com/spreadsheets/d/1ffSUVY0xBc8bmnmwUkEq01rlilnv7Mxl6TLeXR5bQb8/edit#gid=16071388
        {
            _administratorPanel.Error();
            Assert.AreEqual("Pls pick waiter", _administratorPanel.GetCheckErrorStatusForFirstUser());
        }
    }
}