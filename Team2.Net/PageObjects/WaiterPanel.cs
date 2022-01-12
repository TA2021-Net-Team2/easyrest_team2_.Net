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

         public string FindSuccessButton()
         {
             return _webDriver.FindElement(successButton).Text;
         }

        public WaiterPanel CloseOrder()
        {
            SeleniumWaiters.WaitElement(_webDriver, _linkInProgress);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, _linkInProgress);
            _webDriver.FindElement(_linkInProgress).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowMore);
            _webDriver.FindElement(_buttonShowMore).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonClose);
            _webDriver.FindElement(_buttonClose).Click();

            SeleniumWaiters.WaitElement(_webDriver, successButton);

            return new WaiterPanel(_webDriver);
        }

        public WaiterPanel StartOrder()
        {
            SeleniumWaiters.WaitElement(_webDriver, _linkAssignedWaiters);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, _linkInProgress);
            _webDriver.FindElement(_linkAssignedWaiters).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowMore);
            _webDriver.FindElement(_buttonShowMore).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonOrder);
            _webDriver.FindElement(_buttonOrder).Click();

            SeleniumWaiters.WaitElement(_webDriver, successButton);

            return new WaiterPanel(_webDriver);
        }

        public WaiterPanel CloseOrderInAll()
        {
            SeleniumWaiters.WaitElement(_webDriver, _progressButton);
            _webDriver.FindElement(_progressButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonClose);
            _webDriver.FindElement(_buttonClose).Click();

            SeleniumWaiters.WaitElement(_webDriver, successButton);

            return new WaiterPanel(_webDriver);
            
        }

        public WaiterPanel StartOrderInAll()
        {
            SeleniumWaiters.WaitElement(_webDriver, _waiterButton);
            _webDriver.FindElement(_waiterButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonOrder);
            _webDriver.FindElement(_buttonOrder).Click();

            SeleniumWaiters.WaitElement(_webDriver, successButton);

            return new WaiterPanel(_webDriver);
        }

    }

}
