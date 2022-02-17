using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

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

        [Test(Description = "Client log in")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test101_ClientLogin() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=0
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test(Description = "Add more one item in product")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test103_AddingMoreThanOneItemInProduct() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=606467545
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();

            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }

        [Test(Description = "Add more then one item in product from different ")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test104_AddMoreThanOneItemDifferentProduct() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=608855160
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CoctailAddToCart();

            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
        }

        [Test(Description = "Submit order")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test105_SubmitOrder() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1574150349
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.SuccessOrderButton();

            Assert.AreEqual("Order status changed to Waiting for confirm", restaurantMenu.FindSuccessButtonInWindow());
        }

        [Test(Description = "Cancel order")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test106_CancelOrder() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1024542359
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.CancelOrderButton();

            Assert.False(restaurantMenu.GetLocatorForm());
        }

        [Test(Description = "Remove item from card")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test107_RemoveItemFromCart() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1634214018
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCartThenRemove();

            Assert.AreEqual("Item was removed", restaurantMenu.FindSuccessRemovingButton());
        }

        [Test(Description = "Remove item from preview")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test108_RemoveItemFromPreview() // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1560135943
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            restaurantMenu.RemoveOrderButton();

            Assert.AreEqual("Item was removed", restaurantMenu.FindSuccessRemovingButton());
        }
        [Test(Description = "Change delivery date")]
        [AllureTag]
        [AllureOwner("Swshcho")]
        public void Test109_ChangeDeliveryDayTest()
        {
            _restaurantsList.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();
            SeleniumWaiters.WaitSomeInterval(1);
            restaurantMenu.DatePickerButton();
            Assert.AreEqual("Book time selected", restaurantMenu.FindOKButton());
            SeleniumWaiters.WaitSomeInterval(3);
        }


        [Test(Description = "Delete from draft")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test111_MakeDeleteFromDraft()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=381700871
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeleteFromDraft();

            Assert.AreEqual("Order deleted", _clientPanel.IdentificateDeletedFromDraft());
        }

        [Test(Description = "Decline from waiting")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test112_MakeDeclinedFromWaiting()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=392363947
        {
            MyCurrentOrdersListTest();
            _clientPanel.MakeDeclinedFromWaiting();

            Assert.AreEqual("Order declined", _clientPanel.IdentificateDeclinedFromWaiting());
        }
        [Test(Description = "Order from history")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test113_MakeReorderFromHistory()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1151572713
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromHistory();

            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test(Description = "Reorder from declined")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test114_MakeReorderFromDeclined()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=755782380
        {
            MyHistoryOrdersListTest();
            _clientPanel.MakeReorderFromDeclined();

            Assert.AreEqual("Order status changed to Waiting for confirm", _clientPanel.WaitingForConfirm());
        }

        [Test(Description = "Watch accepted order")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test115_WatchAcceptedOrdersTab()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1379820078
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test(Description = "Watch assigned waiter")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test116_WatchAssignedWaiterTab()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=1318815748
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressTabAssepted();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test(Description = "Watch in progres")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test117_WatchInProgressTab()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=885437076
        {
            MyCurrentOrdersListTest();
            _clientPanel.PressInProgress();

            Assert.True(_clientPanel.IdentificateShowLess());
        }

        [Test(Description = "Watch remove order")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test118_WatchRemovedOrders()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=550489601
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressRemovedOrders();

            Assert.True(_clientPanel.GetIdentificateSelected());
        }

        [Test(Description = "Watch fail order")]
        [AllureTag]
        [AllureOwner("Zaiets")]
        public void Test119_WatchFaildOrders()  // https://docs.google.com/spreadsheets/d/1-DL9WQZBF4N6WUc0keOpIv_9qXJO18ZXtlK15-sxMvk/edit#gid=291538558
        {
            MyHistoryOrdersListTest();
            _clientPanel.PressFaildOrders();

            Assert.True(_clientPanel.GetIdentificateSelected());
        }
    }
}