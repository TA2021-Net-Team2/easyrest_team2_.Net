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

        private WaiterPanel _waiterPanel;
        private BasePage _basePage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            WaiterLogin();
            _waiterPanel = new WaiterPanel(_webDriver);
            _basePage = new BasePage(_webDriver);
        }

        private void WaiterLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginWaiter, PasswordWaiter);
        }

        [Test]
        public void Test601_WaiterLogin() // https://docs.google.com/spreadsheets/d/1qwtfhe3EwPgK_oSZD8-hsIk7unHBBR_vsAPIzqL431c/edit#gid=736636292
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test]
        public void Test602_CloseOrderInAllPannel() // https://docs.google.com/spreadsheets/d/1qwtfhe3EwPgK_oSZD8-hsIk7unHBBR_vsAPIzqL431c/edit#gid=393328420
        {
            _waiterPanel.CloseOrderInAll();

            Assert.AreEqual("success", _waiterPanel.FindSuccessButton());
        }

        [Test]
        public void Test603_StartOrderInAllPannel() // https://docs.google.com/spreadsheets/d/1qwtfhe3EwPgK_oSZD8-hsIk7unHBBR_vsAPIzqL431c/edit#gid=1738436645
        {
            _waiterPanel.StartOrderInAll();

            Assert.AreEqual("success", _waiterPanel.FindSuccessButton());
        }
        [Test]
        public void Test604_StartOrderInWaiterPanel() // https://docs.google.com/spreadsheets/d/1qwtfhe3EwPgK_oSZD8-hsIk7unHBBR_vsAPIzqL431c/edit#gid=732004908
        {
            _waiterPanel.StartOrder();

            Assert.AreEqual("success", _waiterPanel.FindSuccessButton());
        }

        [Test]
        public void Test605_CloseOrderInProgress() // https://docs.google.com/spreadsheets/d/1qwtfhe3EwPgK_oSZD8-hsIk7unHBBR_vsAPIzqL431c/edit#gid=277716498
        {
            _waiterPanel.CloseOrder();

            Assert.AreEqual("success", _waiterPanel.FindSuccessButton());
        }
    }
}
