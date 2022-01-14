using OpenQA.Selenium;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class Authorization : BasePage
    {
        public Authorization(IWebDriver webDriver) : base(webDriver)
        {
        }
        public string GetSignInPage()
        {
            return _webDriver.FindElement(signInText).Text;
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
        public string GetErrorAutorizationGoogle()
        {
            return _webDriver.FindElement(ErrorText).Text;
        }
        
        public Authorization SignInFromGoogleAccount()
        {
            SeleniumWaiters.WaitElement(_webDriver, GoogleButton);
            _webDriver.FindElement(GoogleButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, ErrorText);

            return new Authorization(_webDriver);
        }
    }
}
