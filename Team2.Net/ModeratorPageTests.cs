using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class ModeratorPageTests : BaseTest
    {
        private const string StartLoginModerator = "petermoderator@test.com";
        private const string PasswordModerator = "1";

        //Створи свій пейдж
        //private ModeratorPanel _moderatorPanel;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            ModeratorLogin();
            //_moderatorPanel = new ModeratorPanel(_webDriver);
        }

        private void ModeratorLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginModerator, PasswordModerator);
        }

        [Test]
        public void YourTest()
        {

        }
    }
}