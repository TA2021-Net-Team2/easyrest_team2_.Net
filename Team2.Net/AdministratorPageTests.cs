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

        //Створи свій пейдж
        //private AdministratorPanel _administratorPanel;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            AdministratorLogin();
            //_administratorPanel = new AdministratorPanel(_webDriver);
        }

        private void AdministratorLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginAdministrator, PasswordAdministrator);
        }

        [Test]
        public void YourTest()
        {

        }
    }
}