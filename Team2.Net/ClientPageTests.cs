using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class ClientPageTests : BaseTest
    {
        private const string StartLoginClient = "katherinebrennan@test.com";
        private const string PasswordClient = "1111";

        //Створи свій пейдж
        //private ClientPanel _clientPanel;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            ClientLogin();
            //_clientPanel = new ClientPanel(_webDriver);
        }

        private void ClientLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginClient, PasswordClient);
        }

        [Test]
        public void YourTest()
        {

        }
    }
}