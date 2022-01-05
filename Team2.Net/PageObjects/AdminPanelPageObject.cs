using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Team2.Net.PageObjects
{
    class AdminPanelPageObject
    {

        private IWebDriver _webDriver;

        private readonly By _usersListButton = By.CssSelector("a[href='/admin/users']");
        private readonly By _ownersListButton = By.CssSelector("a[href='/admin/owners']");
        private readonly By _moderatorsListButton = By.CssSelector("a[href='/admin/moderators']");
        private readonly By _restaurantsListButton = By.CssSelector("a[href='/admin/restaurants']");

        public AdminPanelPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AdminPanelPageObject LockUser()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_usersListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanelPageObject(_webDriver);
        }

        public AdminPanelPageObject UnlockUser()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_usersListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanelPageObject(_webDriver);
        }

        public AdminPanelPageObject LockOwner()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_ownersListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanelPageObject(_webDriver);
        }

        public AdminPanelPageObject UnlockOwner()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_ownersListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanelPageObject(_webDriver);
        }

        public AdminPanelPageObject LockModerator()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_moderatorsListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanelPageObject(_webDriver);
        }

        public AdminPanelPageObject UnlockModerator()
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_moderatorsListButton).Click();
            Thread.Sleep(2000);

            return new AdminPanelPageObject(_webDriver);
        }
    }
}
