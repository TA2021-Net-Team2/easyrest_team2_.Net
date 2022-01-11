using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class RestaurantMenu
    {
        private IWebDriver _webDriver;

        public RestaurantMenu(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public RestaurantMenu CoctailAddToCart()
        {
            _webDriver.FindElement(CoctailMenuInput).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);
            SeleniumWaiters.WaitSomeInterval(1);
            _webDriver.FindElement(CoctailMenuInput).SendKeys("3");
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(CoctailAddToCartButton).Click();
            SeleniumWaiters.WaitSomeInterval(1);
            _webDriver.FindElement(SubmitOrderButton).Click();
            SeleniumWaiters.WaitSomeInterval(1);
            return new RestaurantMenu(_webDriver);
        }
    }
}
