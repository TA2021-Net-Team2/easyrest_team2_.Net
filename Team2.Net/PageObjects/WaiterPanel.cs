using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class WaiterPanel
    {
        private IWebDriver _webDriver;

        public WaiterPanel(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        
        public WaiterPanel CloseOrder()
        {
            SeleniumWaiters.WaitElement(_webDriver, _linkInProgress);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, _linkInProgress);
            _webDriver.FindElement(_linkInProgress).Click();

            return new WaiterPanel(_webDriver);
        }
    }

}
