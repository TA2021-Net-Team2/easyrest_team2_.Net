using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;
using OpenQA.Selenium;

namespace Team2.Net.PageObjects
{
    public partial class Registration
    {
        private readonly By SignUpForm = By.XPath("//div[contains(@class, 'SignUpForm')]");

        // Create Account Form
        private readonly By NameInput = By.XPath("//input[@name='name']");
        private readonly By EmailInput = By.XPath("//input[@name='email']");
        private readonly By PhoneNumberInput = By.XPath("//input[@name='phoneNumber']");
        private readonly By PasswordInput = By.XPath("//input[@name='password']");
        private readonly By ConfirmPasswordInput = By.XPath("//input[@name='repeated_password']");

        private readonly By BirthdDateInput = By.XPath("//input[@name='birthDate']");

        // Modal window Date Picker
        private static string DatePickerModalWindow = "//div[contains(@class, 'PickersModal')]";
        private readonly By DatePickerYear = By.XPath(DatePickerModalWindow + "//h6[contains(@class, 'subtitle')]");
        private readonly By DatePickerSelectYear = By.XPath(DatePickerModalWindow + "//div[contains(text(),'1971')]");
        private readonly By DatePickerOkButton = By.XPath(DatePickerModalWindow + "//span[contains(text(),'OK')]");

        private readonly By CreateAccountButton = By.XPath("//span[contains(text(),'Create account')]");
    }
}
