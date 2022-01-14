using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class RestaurantsList
    {
        private IWebDriver _webDriver;

        public RestaurantsList(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public RestaurantsList CreateOrder()
        {
            SeleniumWaiters.WaitElement(_webDriver, WatchMenu);
            _webDriver.FindElement(WatchMenu).Click();

            return new RestaurantsList(_webDriver);
        }  
    }
}
