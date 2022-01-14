using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;
using OpenQA.Selenium;

namespace Team2.Net.PageObjects
{
    public partial class Registration : BasePage
    {
        public Registration(IWebDriver webDriver) : base(webDriver)
        {
        }

        public BasePage SignUp()
        {
            string nameInput = "Austin Powers";
            string emailInput = "austinpowersowner@test.com";
            string phoneNumberInput = "+380000001231";
            string passwordInput = "12345678";
            string passwordConfirmInput = "12345678";

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
            SeleniumWaiters.WaitElement(_webDriver, SignUpForm);

            _webDriver.FindElement(DatePickerYear).Click();
            SeleniumWaiters.WaitElement(_webDriver, DatePickerSelectYear);

            _webDriver.FindElement(DatePickerSelectYear).Click();
            SeleniumWaiters.WaitElement(_webDriver, DatePickerOkButton);

            _webDriver.FindElement(DatePickerOkButton).Click();
            SeleniumWaiters.WaitElement(_webDriver, CreateAccountButton);

            _webDriver.FindElement(CreateAccountButton).Click();

            SeleniumWaiters.ShouldLocate(_webDriver, "http://localhost:3000/log-in");

            return new BasePage(_webDriver);
        }

    }
}
