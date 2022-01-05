using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _emailInputButton = By.XPath("//input[@name='email']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='password']");

        private readonly By _loginButton = By.XPath("//button[@type='submit']");

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject Login(string login, string password)
        {
            _webDriver.FindElement(_emailInputButton).SendKeys(login);
            _webDriver.FindElement(_passwordInputButton).SendKeys(password);

            Thread.Sleep(1000);

            _webDriver.FindElement(_loginButton).Click();

            return new MainMenuPageObject(_webDriver);
        }
    }
}
