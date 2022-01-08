using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class AdminPanel
    {
        private IWebDriver _webDriver;

        public AdminPanel(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetActivityStatusForFirstUser()
        {
            return _webDriver.FindElement(FirstUserActivityStatus).Text;
        }

        public AdminPanel LockFirstUser()
        {
            ExplicitWaiters.WaitElementDisplayed(_webDriver, _usersListButton);
            _webDriver.FindElement(_usersListButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, listUsers);
            _webDriver.FindElement(FirstUserButtonLock).Click();

            return new AdminPanel(_webDriver);
        }

        public AdminPanel UnlockFirstUser()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_usersListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanel(_webDriver);
        }

        public AdminPanel LockOwner()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_ownersListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanel(_webDriver);
        }

        public AdminPanel UnlockOwner()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_ownersListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanel(_webDriver);
        }

        public AdminPanel LockModerator()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_moderatorsListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanel(_webDriver);
        }

        public AdminPanel UnlockModerator()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_moderatorsListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanel(_webDriver);
        }
    }

}
