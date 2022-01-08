using OpenQA.Selenium;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public class AuthorizationPageObject : BasePage
    {
        private readonly By _emailInputButton = By.XPath("//input[@name='email']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='password']");
        private readonly By _loginButton = By.XPath("//button[@type='submit']");

        public AuthorizationPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        public BasePage Login(string login, string password)
        {
            _webDriver.FindElement(_emailInputButton).SendKeys(login);
            ExplicitWaiters.WaitForTextEntered(_webDriver, _emailInputButton, login);

            _webDriver.FindElement(_passwordInputButton).SendKeys(password);
            ExplicitWaiters.WaitForCoveredTextEntered(_webDriver, _passwordInputButton, password);

            _webDriver.FindElement(_loginButton).Click();

            return new BasePage(_webDriver);
        }
    }
}
