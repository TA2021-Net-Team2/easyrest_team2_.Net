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

        
        public bool IdentificateShowLess()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, _buttonShowLess);
        }

        public string IdentificateDeletedFromDraft()
        {
            return _webDriver.FindElement(_deletedOrderButton).Text;
        }

        public string IdentificateDeclinedFromWaiting()
        {
            return _webDriver.FindElement(_declinedOrderButton).Text;
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

        public ClientPanel PressTabAssepted()
        {
           
            SeleniumWaiters.WaitElement(_webDriver, _buttonAcceptedOrders);
            _webDriver.FindElement(_buttonAcceptedOrders).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowList);
            _webDriver.FindElement(_buttonShowList).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new ClientPanel(_webDriver);
        }

        public ClientPanel AssignedWaiterTab()
        {

            SeleniumWaiters.WaitElement(_webDriver, _buttonAssignedWaiter);
            _webDriver.FindElement(_buttonAssignedWaiter).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowList);
            _webDriver.FindElement(_buttonShowList).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new ClientPanel(_webDriver);
        }

        public ClientPanel PressInProgress()
        {

            SeleniumWaiters.WaitElement(_webDriver, _buttonPressInProgress);
            _webDriver.FindElement(_buttonPressInProgress).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowList);
            _webDriver.FindElement(_buttonShowList).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new ClientPanel(_webDriver);
        }


        public ClientPanel PressRemovedOrders()
        {

            SeleniumWaiters.WaitElement(_webDriver, _buttonRemoved);
            _webDriver.FindElement(_buttonRemoved).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new ClientPanel(_webDriver);
        }

        public ClientPanel PressFaildOrders()
        {

            SeleniumWaiters.WaitElement(_webDriver, _buttonFailed);
            _webDriver.FindElement(_buttonFailed).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new ClientPanel(_webDriver);
        }

        public ClientPanel MakeDeleteFromDraft()
        {
            SeleniumWaiters.WaitElement(_webDriver, _tabDraft);
            _webDriver.FindElement(_tabDraft).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowList);
            _webDriver.FindElement(_buttonShowList).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonDeletefromDraft);
            _webDriver.FindElement(_buttonDeletefromDraft).Click();

            SeleniumWaiters.WaitElement(_webDriver, _deletedOrderButton);

            return new ClientPanel(_webDriver);
        }


        public ClientPanel MakeDeclinedFromWaiting()
        {
            SeleniumWaiters.WaitElement(_webDriver, _tabWaitingForConfirm);
            _webDriver.FindElement(_tabWaitingForConfirm).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonShowList);
            _webDriver.FindElement(_buttonShowList).Click();

            SeleniumWaiters.WaitElement(_webDriver, _buttonDeclinefromWaiting);
            _webDriver.FindElement(_buttonDeclinefromWaiting).Click();

            SeleniumWaiters.WaitElement(_webDriver, _declinedOrderButton);

            return new ClientPanel(_webDriver);
        }

        




    }

}
