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
        private readonly By FirstUserButtonLockStatusActive = By.XPath(listUsersXPath + "//p[contains(text(),'Active')]//following::button[1]");
        private readonly By FirstUserButtonLockStatusBanned = By.XPath(listUsersXPath + "//p[contains(text(),'Banned')]//following::button[1]");
        private readonly By FirstUserActivityStatus = By.XPath(listUsersXPath + "//p[1]");

        // Moderator
        private readonly By AddModeratorButton = By.CssSelector("a[href='/admin/moderators/create']");
        private readonly By CreateModeratorAccountForm = By.XPath("//div[contains(@class, 'UserCreate')]");

        // Create Moderator Account Form
        private readonly By NameInput = By.XPath("//input[@name='name']");
        private readonly By EmailInput = By.XPath("//input[@name='email']");
        private readonly By PhoneNumberInput = By.XPath("//input[@name='phoneNumber']");
        private readonly By PasswordInput = By.XPath("//input[@name='password']");
        private readonly By ConfirmPasswordInput = By.XPath("//input[@name='repeated_password']");
        private readonly By BithdDateInput = By.XPath("//input[@name='birthDate']");

    }
}
