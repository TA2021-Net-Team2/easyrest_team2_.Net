using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team2.Net.PageObjects
{
	public partial class ClientPanel
	{
        private IWebDriver _webDriver;
        public ClientPanel(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }
        
        public RestaurantsList OpenWatchMenu()
        {
            SeleniumWaiters.WaitElement(_webDriver, WatchMenu);
            _webDriver.FindElement(WatchMenu).Click();

            return new RestaurantsList(_webDriver);
        }
    }
}

