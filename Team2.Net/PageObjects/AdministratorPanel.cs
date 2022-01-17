using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class AdministratorPanel
    {
        private IWebDriver _webDriver;

        public AdministratorPanel(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool GetAcceptionStatusForFirstUser()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, Check_accept);
        }
        public bool GetAssignStatusForFirstUser()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, Check_assign);
        }
        public string GetCheckErrorStatusForFirstUser()
        {
            return _webDriver.FindElement(Error_assign).Text;
        }

        public bool GetWaiterAssignedPanelBack()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, WaitersCloseChecker);
        }

        public AdministratorPanel Acception_func()
        {
            SeleniumWaiters.WaitElement(_webDriver, Arrow);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, Arrow);
            _webDriver.FindElement(Arrow).Click();

            SeleniumWaiters.WaitElement(_webDriver, ActiveStatus);
            _webDriver.FindElement(ActiveStatus).Click();

            SeleniumWaiters.WaitElement(_webDriver, Check_accept);

            return new AdministratorPanel(_webDriver);
        }

        public AdministratorPanel Assign_waiter_func()
        {
            SeleniumWaiters.WaitElement(_webDriver, Accepted_tab);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, Arrow_Down);
            _webDriver.FindElement(Accepted_tab).Click();

            SeleniumWaiters.WaitElement(_webDriver, Arrow);
            _webDriver.FindElement(Arrow).Click();

            SeleniumWaiters.WaitElement(_webDriver, Radiobutton);
            _webDriver.FindElement(Radiobutton).Click();

            SeleniumWaiters.WaitElement(_webDriver, Assign_waiter);
            _webDriver.FindElement(Assign_waiter).Click();

            SeleniumWaiters.WaitElement(_webDriver, Check_assign);

            return new AdministratorPanel(_webDriver);
        }
        public AdministratorPanel Error()
        {
            SeleniumWaiters.WaitElement(_webDriver, Accepted_tab);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, Arrow_Down);
            _webDriver.FindElement(Accepted_tab).Click();

            SeleniumWaiters.WaitElement(_webDriver, Arrow);
            _webDriver.FindElement(Arrow).Click();

            SeleniumWaiters.WaitElement(_webDriver, Assign_waiter);
            _webDriver.FindElement(Assign_waiter).Click();

            SeleniumWaiters.WaitElement(_webDriver, Error_assign);

            return new AdministratorPanel(_webDriver);
        }

        public AdministratorPanel Watch_info_waiter()
        {
            SeleniumWaiters.WaitElement(_webDriver, Assign_waiter_tab);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, Arrow_Down);
            _webDriver.FindElement(Assign_waiter_tab).Click();

            SeleniumWaiters.WaitElement(_webDriver, Arrow);
            _webDriver.FindElement(Arrow).Click();

            SeleniumWaiters.WaitElement(_webDriver, Arrow);
            _webDriver.FindElement(Arrow).Click();

            return new AdministratorPanel(_webDriver);
        }

        public AdministratorPanel Waiters_tab_info()
        {
            SeleniumWaiters.WaitElement(_webDriver, Waiter_tab);
            //ExplicitWaiters.WaitElementDisplayed(_webDriver, Arrow_Down);
            _webDriver.FindElement(Waiter_tab).Click();

            SeleniumWaiters.WaitElement(_webDriver, Arrow);
            _webDriver.FindElement(Arrow).Click();

            SeleniumWaiters.WaitElement(_webDriver, Second_Arrow);
            _webDriver.FindElement(Second_Arrow).Click();
            
            SeleniumWaiters.WaitElement(_webDriver, Second_Arrow);
            _webDriver.FindElement(Second_Arrow).Click();

            SeleniumWaiters.WaitElement(_webDriver, Arrow);
            _webDriver.FindElement(Arrow).Click();

            return new AdministratorPanel(_webDriver);
        }
    }

}

