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
        private RestaurantMenu restaurantMenu;
        private RestaurantsList _restaurantsList;


        [SetUp]
        public override void Setup()
        {
            base.Setup();

            ClientLogin();
            _clientPanel = new ClientPanel(_webDriver);
            _restaurantsList = new RestaurantsList(_webDriver);
            restaurantMenu = new RestaurantMenu(_webDriver);
        }

        private void ClientLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginClient, PasswordClient);
        }

        public void MyCurrentOrdersListTest()  // Current orders
        {
            _restaurantsList.RedirectToPersonalInfo();
            _clientPanel.MyCurrentOrders();
        }

        public void MyHistoryOrdersListTest()  // History
        {
            _restaurantsList.RedirectToPersonalInfo();
            _clientPanel.MyHistoryOrders();
        }


        [Test]
        public void MyPersonalInfoListTest()  //personal info
        {
            _restaurantsList.RedirectToPersonalInfo();
            Assert.AreEqual("katherinebrennan@test.com", _clientPanel.IdentificateEmail());
        }

        [Test]
        public void MakeReorderFromHistoryTest()  // 113
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromHistory();
            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test]
        public void MakeReorderFromDeclinedTest()  // 114
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromDeclined();
            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test]
        public void WatchAcceptedOrdersTabTest()  // 115
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();
            Assert.True(_clientPanel.IdentificateShowLess());
          
        }
               
        [Test]
        public void WatchAssignedWaiterTabTest()  // 116
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();
            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void WatchInProgressTabTest()  // 117
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressInProgress();
            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void WatchRemovedOrdersTest()  // 118
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressRemovedOrders();
            Assert.True(_clientPanel.GetIdentificateSelected());

        }

        [Test]
        public void WatchFaildOrdersTest()  // 119
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressFaildOrders();
            Assert.True(_clientPanel.GetIdentificateSelected());
        }

        [Test]
        public void MakeDeleteFromDraftTest()  // 111
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeleteFromDraft();
            Assert.AreEqual("Order deleted", _clientPanel.IdentificateDeletedFromDraft());

        }

        [Test]
        public void AddingMoreThanOneItemInProductTest()
        {
            _clientPanel.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }
        [Test]
        public void MakeDeclinedFromWaitingTest()  // 112
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeclinedFromWaiting();
            Assert.AreEqual("Order declined", _clientPanel.IdentificateDeclinedFromWaiting());
        }

        [Test]
        public void AddMoreThanOneItemDifferentProductTest()
		{
			_clientPanel.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CoctailAddToCart();
            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }
        [Test]
        public void SubmitOrderTest()
		{
            _clientPanel.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.SuccessOrderButton();
            Assert.AreEqual("Order status changed to Waiting for confirm", restaurantMenu.FindSuccessButtonInWindow());
        }
        [Test]
        public void CancelOrderTest()
		{
            _clientPanel.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CancelOrderButton();
            Assert.False(restaurantMenu.GetLocatorForm());
        }
        [Test]
        public void RemoveItemFromCartTest()
		{
            _clientPanel.OpenWatchMenu();
            restaurantMenu.BakeryAddToCartThenRemove();
            Assert.AreEqual("Item was removed", restaurantMenu.FindSuccessRemovingButton());
        }
        [Test]
        public void RemoveItemFromPreviewTest()
		{
            _clientPanel.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.RemoveOrderButton();
            Assert.AreEqual("Item was removed", restaurantMenu.FindSuccessRemovingButton());
        }
        /* [Test]
        public void ChangeDeliveryDayTest()
         {
             _clientPanel.OpenWatchMenu();
             restaurantMenu.BakeryAddToCart();
             Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
             restaurantMenu.DatePickerButton();
             SeleniumWaiters.WaitSomeInterval(3);
         } */ //In progress
    }
}