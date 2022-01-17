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
        private BasePage _basePage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            ClientLogin();
            _clientPanel = new ClientPanel(_webDriver);
            _restaurantsList = new RestaurantsList(_webDriver);
            restaurantMenu = new RestaurantMenu(_webDriver);
            _basePage = new BasePage(_webDriver);
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

        public void MyPersonalInfoListTest()  //personal info
        {
            _restaurantsList.RedirectToPersonalInfo();
            //Assert.AreEqual("katherinebrennan@test.com", _clientPanel.IdentificateEmail());
        }

        [Test]
        public void Test101_ClientLogin()
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test]
        public void Test103_AddingMoreThanOneItemInProduct()
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();

            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }

        [Test]
        public void Test104_AddMoreThanOneItemDifferentProduct()
		{
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CoctailAddToCart();

            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }

        [Test]
        public void Test105_SubmitOrder()
		{
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.SuccessOrderButton();

            Assert.AreEqual("Order status changed to Waiting for confirm", restaurantMenu.FindSuccessButtonInWindow());
        }

        [Test]
        public void Test106_CancelOrder()
		{
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CancelOrderButton();

            Assert.False(restaurantMenu.GetLocatorForm());
        }

        [Test]
        public void Test107_RemoveItemFromCart()
		{
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCartThenRemove();

            Assert.AreEqual("Item was removed", restaurantMenu.FindSuccessRemovingButton());
        }

        [Test]
        public void Test108_RemoveItemFromPreview()
		{
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.RemoveOrderButton();

            Assert.AreEqual("Item was removed", restaurantMenu.FindSuccessRemovingButton());
        }

        // in progress

        /* [Test]
        public void ChangeDeliveryDayTest()
         {
             _clientPanel.OpenWatchMenu();
             restaurantMenu.BakeryAddToCart();
             Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
             restaurantMenu.DatePickerButton();
             SeleniumWaiters.WaitSomeInterval(3);
         } */

        [Test]
        public void Test111_MakeDeleteFromDraft()  // 111
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeleteFromDraft();

            Assert.AreEqual("Order deleted", _clientPanel.IdentificateDeletedFromDraft());
        }

        [Test]
        public void Test112_MakeDeclinedFromWaiting()  // 112
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeclinedFromWaiting();

            Assert.AreEqual("Order declined", _clientPanel.IdentificateDeclinedFromWaiting());
        }
        [Test]
        public void Test113_MakeReorderFromHistory()  // 113
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromHistory();

            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test]
        public void Test114_MakeReorderFromDeclined()  // 114
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromDeclined();

            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test]
        public void Test115_WatchAcceptedOrdersTab()  // 115
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void Test116_WatchAssignedWaiterTab()  // 116
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void Test117_WatchInProgressTab()  // 117
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressInProgress();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void Test118_WatchRemovedOrders()  // 118
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressRemovedOrders();

            Assert.True(_clientPanel.GetIdentificateSelected());
        }

        [Test]
        public void Test119_WatchFaildOrders()  // 119
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressFaildOrders();

            Assert.True(_clientPanel.GetIdentificateSelected());
        }
    }
}