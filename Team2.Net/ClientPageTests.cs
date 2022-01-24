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
        public void Test101_ClientLogin() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=0
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test]
        public void Test103_AddingMoreThanOneItemInProduct() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=606467545
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();

            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }

        [Test]
        public void Test104_AddMoreThanOneItemDifferentProduct() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=608855160
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CoctailAddToCart();

            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }

        [Test]
        public void Test105_SubmitOrder() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1574150349
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.SuccessOrderButton();

            Assert.AreEqual("Order status changed to Waiting for confirm", restaurantMenu.FindSuccessButtonInWindow());
        }

        [Test]
        public void Test106_CancelOrder() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1024542359
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CancelOrderButton();

            Assert.False(restaurantMenu.GetLocatorForm());
        }

        [Test]
        public void Test107_RemoveItemFromCart() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1634214018
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCartThenRemove();

            Assert.AreEqual("Item was removed", restaurantMenu.FindSuccessRemovingButton());
        }

        [Test]
        public void Test108_RemoveItemFromPreview() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1560135943
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
        public void Test111_MakeDeleteFromDraft()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=381700871
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeleteFromDraft();

            Assert.AreEqual("Order deleted", _clientPanel.IdentificateDeletedFromDraft());
        }

        [Test]
        public void Test112_MakeDeclinedFromWaiting()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=392363947
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeclinedFromWaiting();

            Assert.AreEqual("Order declined", _clientPanel.IdentificateDeclinedFromWaiting());
        }
        [Test]
        public void Test113_MakeReorderFromHistory()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1151572713
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromHistory();

            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test]
        public void Test114_MakeReorderFromDeclined()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=755782380
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromDeclined();

            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test]
        public void Test115_WatchAcceptedOrdersTab()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1379820078
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void Test116_WatchAssignedWaiterTab()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1318815748
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void Test117_WatchInProgressTab()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=885437076
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressInProgress();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test]
        public void Test118_WatchRemovedOrders()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=550489601
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressRemovedOrders();

            Assert.True(_clientPanel.GetIdentificateSelected());
        }

        [Test]
        public void Test119_WatchFaildOrders()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=291538558
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressFaildOrders();

            Assert.True(_clientPanel.GetIdentificateSelected());
        }
    }
}