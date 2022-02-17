using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace Team2.Net
{
    public class BasePageTest : BaseTest
    {
        private BasePage _basePage;
        private Authorization autorizationPage;
        private RestaurantsList restaurantsListPage;
        private RestaurantMenu restaurantMenu;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _basePage = new BasePage(_webDriver);
            autorizationPage = new Authorization(_webDriver);
            restaurantsListPage = new RestaurantsList(_webDriver);
            restaurantMenu = new RestaurantMenu(_webDriver);
        }

        [Test(Description = "Registration")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test409_Registration() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=212817552
        {
            _basePage
                .Registration()
                .SignUp();

            Assert.AreEqual("Sign In", autorizationPage.GetSignInPage());
        }

        [Test(Description = "Create order ")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test410_CreateOrderUnauthorizedUser() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=705429520
        {
            _basePage.OpenRestaurantList();
            restaurantsListPage.CreateOrder();
            restaurantMenu.CoctailAddToCart();

            Assert.AreEqual("Sign In", autorizationPage.GetSignInPage());
        }

        [Test(Description = "Log in from googleaccount")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test411_LogInFromGoogleAccount() // https://docs.google.com/spreadsheets/d/1BuWY7FLzfvljgloPzJyCw3y7gBMUh5banMSJ25ol8IQ/edit#gid=1660078923
        {
            _basePage.SignIn();
            autorizationPage.SignInFromGoogleAccount();

            Assert.AreEqual("The OAuth client was deleted.", autorizationPage.GetErrorAutorizationGoogle());
        }
    }
}
