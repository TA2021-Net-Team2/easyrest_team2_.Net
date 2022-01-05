using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team2.Net.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _signInButton = By.CssSelector("a[href='/log-in']");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();

            return new AuthorizationPageObject(_webDriver);
        }

    }
}
