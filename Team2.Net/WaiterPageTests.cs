using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class WaiterPageTests : BaseTest
    {
        private const string StartLoginWaiter = "jeremyvaughan@test.com";
        private const string PasswordWaiter = "1";

        //Створи свій пейдж
        private WaiterPanel _waiterPanel;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            WaiterLogin();
            _waiterPanel = new WaiterPanel(_webDriver);
        }

        private void WaiterLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginWaiter, PasswordWaiter);
        }

        [Test]
        public void CloseOrderSecond()
        {
            _waiterPanel.CloseOrder();
        }
    }
}
