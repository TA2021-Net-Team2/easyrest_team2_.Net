using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class ClientPanel
    {
        private IWebDriver _webDriver;

        public ClientPanel(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

         public string IdentificateEmail()
         {
             return _webDriver.FindElement(_identificateEmail).Text;
         }

        public string WaitingForConfirm()
        {
            return _webDriver.FindElement(_identificateConfirmAllert).Text;
        }

        public ClientPanel MyCurrentOrders()
        {
            _webDriver.FindElement(_buttonCurrentOrders).Click();
            
            return new ClientPanel(_webDriver);
        }


        public ClientPanel MyHistoryOrders()
        {
            _webDriver.FindElement(_buttonHistoryOrders).Click();
            
            return new ClientPanel(_webDriver);
        }

        
         public ClientPanel MakeReorderFromHistory()
        {
            SeleniumWaiters.WaitElement(_webDriver, _tabHistory);
            _webDriver.FindElement(_tabHistory).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowMoreHistory);
            _webDriver.FindElement(_buttonShowMoreHistory).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonReorderFromHistory);
            _webDriver.FindElement(_buttonReorderFromHistory).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonSubmitFromHistory);
            _webDriver.FindElement(_buttonSubmitFromHistory).Click();

            SeleniumWaiters.WaitElement(_webDriver, _identificateConfirmAllert);

            return new ClientPanel(_webDriver);
        }

        public ClientPanel MakeReorderFromDeclined()
        {
            SeleniumWaiters.WaitElement(_webDriver, _tabDeclined);
            _webDriver.FindElement(_tabDeclined).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowMoreHistory);
            _webDriver.FindElement(_buttonShowMoreHistory).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonReorderFromHistory);
            _webDriver.FindElement(_buttonReorderFromHistory).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonSubmitFromHistory);
            _webDriver.FindElement(_buttonSubmitFromHistory).Click();

            SeleniumWaiters.WaitElement(_webDriver, _identificateConfirmAllert);

            return new ClientPanel(_webDriver);
        }

    }

}
