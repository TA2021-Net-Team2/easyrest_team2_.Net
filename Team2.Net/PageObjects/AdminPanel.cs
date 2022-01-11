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

        //Status First User
        public string GetActivityStatusForFirstUser()
        {
            return _webDriver.FindElement(FirstUserActivityStatus).Text;
        }

        public AdminPanel LockFirstUser()
        {
            SeleniumWaiters.WaitElement(_webDriver, _usersListButton);
            _webDriver.FindElement(_usersListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            //check status Active
            SeleniumWaiters.WaitElement(_webDriver, ActiveStatusXPath);

            _webDriver.FindElement(FirstUserButtonLockStatusActive).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            return new AdminPanel(_webDriver);
        }

        public AdminPanel UnlockFirstUser()
        {
            SeleniumWaiters.WaitElement(_webDriver, _usersListButton);
            _webDriver.FindElement(_usersListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            //check status Banned
            SeleniumWaiters.WaitElement(_webDriver, BannedStatusXPath);

            _webDriver.FindElement(FirstUserButtonLockStatusBanned).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            return new AdminPanel(_webDriver);
        }

        public AdminPanel LockOwner()
        {
            SeleniumWaiters.WaitElement(_webDriver, _ownersListButton);
            _webDriver.FindElement(_ownersListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            //check status Active
            SeleniumWaiters.WaitElement(_webDriver, ActiveStatusXPath);

            _webDriver.FindElement(FirstUserButtonLockStatusActive).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            return new AdminPanel(_webDriver);
        }

        public AdminPanel UnlockOwner()
        {
            SeleniumWaiters.WaitElement(_webDriver, _ownersListButton);
            _webDriver.FindElement(_ownersListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            //check status Banned
            SeleniumWaiters.WaitElement(_webDriver, BannedStatusXPath);

            _webDriver.FindElement(FirstUserButtonLockStatusBanned).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            return new AdminPanel(_webDriver);
        }

        public AdminPanel LockModerator()
        {
            SeleniumWaiters.WaitElement(_webDriver, _moderatorsListButton);
            _webDriver.FindElement(_moderatorsListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            //check status Active
            SeleniumWaiters.WaitElement(_webDriver, ActiveStatusXPath);

            _webDriver.FindElement(FirstUserButtonLockStatusActive).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            return new AdminPanel(_webDriver);
        }

        public AdminPanel UnlockModerator()
        {
            SeleniumWaiters.WaitElement(_webDriver, _moderatorsListButton);
            _webDriver.FindElement(_moderatorsListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            //check status Banned
            SeleniumWaiters.WaitElement(_webDriver, BannedStatusXPath);

            _webDriver.FindElement(FirstUserButtonLockStatusBanned).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            return new AdminPanel(_webDriver);
        }

        //in process...
        public AdminPanel AddModerator()
        {
            string nameInput = "Bodya";
            string emailInput = "bodya@mail.com";
            string phoneNumberInput = "380999999999";
            string passwordInput = "AceW12311";
            string passwordConfirmInput = "AceW12311";

            SeleniumWaiters.WaitElement(_webDriver, _moderatorsListButton);
            _webDriver.FindElement(_moderatorsListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, AddModeratorButton);
            _webDriver.FindElement(AddModeratorButton).Click();

            SeleniumWaiters.WaitSomeInterval(2);

            SeleniumWaiters.WaitElement(_webDriver, CreateModeratorAccountForm);

            _webDriver.FindElement(NameInput).SendKeys(nameInput);
            ExplicitWaiters.WaitForTextEntered(_webDriver, NameInput, nameInput);

            _webDriver.FindElement(EmailInput).SendKeys(emailInput);
            ExplicitWaiters.WaitForTextEntered(_webDriver, EmailInput, emailInput);

            _webDriver.FindElement(PhoneNumberInput).SendKeys(phoneNumberInput);
            ExplicitWaiters.WaitForTextEntered(_webDriver, PhoneNumberInput, phoneNumberInput);

            _webDriver.FindElement(PasswordInput).SendKeys(passwordInput);
            ExplicitWaiters.WaitForTextEntered(_webDriver, PasswordInput, passwordInput);

            _webDriver.FindElement(ConfirmPasswordInput).SendKeys(passwordConfirmInput);
            ExplicitWaiters.WaitForTextEntered(_webDriver, ConfirmPasswordInput, passwordConfirmInput);

            SeleniumWaiters.WaitSomeInterval(2);
            return new AdminPanel(_webDriver);
        }
    }

}
