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
        private ClientPanel _clientPanel;
        private RestaurantMenu restaurantMenu;
        private RestaurantsList restaurantsListPage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            ClientLogin();
            _clientPanel = new ClientPanel(_webDriver);
            restaurantsListPage = new RestaurantsList(_webDriver);
            restaurantMenu = new RestaurantMenu(_webDriver);
        }

        private void ClientLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginClient, PasswordClient);
        }

        [Test]
        public void AddingMoreThanOneItemInProductTest()
        {
            _clientPanel.OpenWatchMenu();
            restaurantMenu.BakeryAddToCart();

            Assert.AreEqual("Item was added", restaurantMenu.FindSuccessButton());
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