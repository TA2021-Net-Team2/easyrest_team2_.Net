using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class BasePage
    {
        protected IWebDriver _webDriver;

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool IsAvatarVisible()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, UserMenuAvatar);
        }

        public AuthorizationPageObject SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();

            return new AuthorizationPageObject(_webDriver);
        }

        public virtual void IsPageLoaded()
        {
            ExplicitWaiters.WaitElementsDisplayed(_webDriver, Header);
        }
    }
}
