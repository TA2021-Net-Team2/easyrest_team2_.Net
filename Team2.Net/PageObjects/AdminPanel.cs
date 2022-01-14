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

        public string GetNameModerator()
        {
            return _webDriver.FindElement(NameModerator).Text;
        }

        public AdminPanel LockFirstUser()
        {
            SeleniumWaiters.WaitElement(_webDriver, _usersListButton);
            _webDriver.FindElement(_usersListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            //check status Active
            SeleniumWaiters.WaitElement(_webDriver, ActiveStatusXPath);

            _webDriver.FindElement(FirstUserButtonLockStatusActive).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

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

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

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

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

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

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

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

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

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

            SeleniumWaiters.WaitElement(_webDriver, listUsers);

            return new AdminPanel(_webDriver);
        }

        public AdminPanel AddModerator()
        {
            string nameInput = "Austin Powers";
            string emailInput = "austinmoderator@test.com";
            string phoneNumberInput = "+380000000753";
            string passwordInput = "12345678";
            string passwordConfirmInput = "12345678";

            SeleniumWaiters.WaitElement(_webDriver, _moderatorsListButton);
            _webDriver.FindElement(_moderatorsListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, AddModeratorButton);
            _webDriver.FindElement(AddModeratorButton).Click();

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
            _webDriver.FindElement(BirthdDateInput).Click();

            SeleniumWaiters.WaitElement(_webDriver, CreateModeratorAccountForm);
            _webDriver.FindElement(DatePickerYear).Click();

            SeleniumWaiters.WaitElement(_webDriver, DatePickerSelectYear);
            _webDriver.FindElement(DatePickerSelectYear).Click();

            SeleniumWaiters.WaitElement(_webDriver, DatePickerOkButton);
            _webDriver.FindElement(DatePickerOkButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, CreateAccountButton);
            _webDriver.FindElement(CreateAccountButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, listUsers);
            
            return new AdminPanel(_webDriver);
        }
    }

}
