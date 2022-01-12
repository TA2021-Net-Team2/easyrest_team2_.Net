using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class AdminPanel
    {
        // Menu buttons
        private readonly By _usersListButton = By.CssSelector("a[href='/admin/users']");
        private readonly By _ownersListButton = By.CssSelector("a[href='/admin/owners']");
        private readonly By _moderatorsListButton = By.CssSelector("a[href='/admin/moderators']");
        private readonly By _restaurantsListButton = By.CssSelector("a[href='/admin/restaurants']");

        // Users
        private static string MainPanelXpath = "//main[contains(@class, 'AdminPanel')]";

        private static string listUsersXPath = MainPanelXpath + "//table[contains(@class, 'Users-table')]";

        private readonly By ActiveStatusXPath = By.XPath("//p[contains(text(),'Active')]");
        private readonly By BannedStatusXPath = By.XPath("//p[contains(text(),'Banned')]");

        private readonly By listUsers = By.XPath(listUsersXPath);

        // Row 
        private static string FirstUserRowWithStatus = "//tbody/tr[contains(@class, 'TableRow')][1]";

        private readonly By FirstUserButtonLockStatusActive = By.XPath(listUsersXPath + "//p[contains(text(),'Active')]//following::button[1]");
        private readonly By FirstUserButtonLockStatusBanned = By.XPath(listUsersXPath + "//p[contains(text(),'Banned')]//following::button[1]");
        private readonly By FirstUserActivityStatus = By.XPath(listUsersXPath + FirstUserRowWithStatus+ "//p[last()]");

        // Moderator
        private readonly By AddModeratorButton = By.CssSelector("a[href='/admin/moderators/create']");
        private readonly By CreateModeratorAccountForm = By.XPath("//div[contains(@class, 'UserCreate')]");
        
        // Create Moderator Account Form
        private readonly By NameInput = By.XPath("//input[@name='name']");
        private readonly By EmailInput = By.XPath("//input[@name='email']");
        private readonly By PhoneNumberInput = By.XPath("//input[@name='phoneNumber']");
        private readonly By PasswordInput = By.XPath("//input[@name='password']");
        private readonly By ConfirmPasswordInput = By.XPath("//input[@name='repeated_password']");

        private readonly By BirthdDateInput = By.XPath("//input[@name='birthDate']");

        // Modal window Date Picker
        private static string DatePickerModalWindow = "//div[contains(@class, 'PickersModal')]";
        private readonly By DatePickerYear = By.XPath(DatePickerModalWindow + "//h6[contains(@class, 'subtitle')]");
        private readonly By DatePickerSelectYear = By.XPath(DatePickerModalWindow + "//div[contains(text(),'1970')]");
        private readonly By DatePickerOkButton = By.XPath(DatePickerModalWindow + "//span[contains(text(),'OK')]");

        private readonly By CreateAccountButton = By.XPath("//span[contains(text(),'Create account')]");

        //Status Moderator in list
        private readonly By NameModerator = By.XPath(listUsersXPath + "//th[contains(text(), 'Austin Powers')]");
    }
}
