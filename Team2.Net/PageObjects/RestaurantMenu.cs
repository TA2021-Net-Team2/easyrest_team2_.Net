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
            SeleniumWaiters.WaitElement(_webDriver, CoctailMenuInput); 
            _webDriver.FindElement(CoctailMenuInput).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);

            SeleniumWaiters.WaitElement(_webDriver, CoctailMenuInput);
            _webDriver.FindElement(CoctailMenuInput).SendKeys("3");

            SeleniumWaiters.WaitElement(_webDriver, CoctailAddToCartButton);
            _webDriver.FindElement(CoctailAddToCartButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButton);
            _webDriver.FindElement(SubmitOrderButton).Click();

            return new RestaurantMenu(_webDriver);
        }
    }
}
