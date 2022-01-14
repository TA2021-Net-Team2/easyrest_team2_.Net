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

        private ClientPanel _clientPanel;
        private RestaurantsList _restaurantsList;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            ClientLogin();
            _clientPanel = new ClientPanel(_webDriver);
            _restaurantsList = new RestaurantsList(_webDriver);
        }

        private void ClientLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginClient, PasswordClient);
        }

        [Test]
        public void MyPersonalInfoListTest()  //personal info
        {
            _restaurantsList.RedirectToPersonalInfo();
            Assert.AreEqual("katherinebrennan@test.com", _clientPanel.IdentificateEmail());
        }

        [Test]
        public void MyCurrentOrdersListTest()  // Current orders
        {
            MyPersonalInfoListTest();
            _clientPanel.MyCurrentOrders();
            //Assert.AreEqual("katherinebrennan@test.com", _clientPanel.IdentificateEmail()); доробить перевірку
        }

        [Test]
        public void MyHistoryOrdersListTest()  // History
        {
            MyPersonalInfoListTest();
            _clientPanel.MyHistoryOrders();
            //Assert.AreEqual("katherinebrennan@test.com", _clientPanel.IdentificateEmail());   доробить перевірку
        }

        [Test]
        public void MakeReorderFromHistoryTest()  // 113
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromHistory();
            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test]
        public void MakeReorderFromDeclinedTest()  // 113
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromDeclined();
            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }
    }
}