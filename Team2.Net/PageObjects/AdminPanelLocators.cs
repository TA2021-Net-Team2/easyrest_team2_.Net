using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class AdminPanel
    {
        private readonly By _usersListButton = By.CssSelector("a[href='/admin/users']");
        private readonly By _ownersListButton = By.CssSelector("a[href='/admin/owners']");
        private readonly By _moderatorsListButton = By.CssSelector("a[href='/admin/moderators']");
        private readonly By _restaurantsListButton = By.CssSelector("a[href='/admin/restaurants']");
        
        private static string listUsersXPath = MainPanelXpath + "//table[contains(@class, 'Users-table')]";
        private readonly By listUsers = By.XPath(listUsersXPath);
        private readonly By FirstUserButtonLock = By.XPath(listUsersXPath + "//button[1]");
        private readonly By FirstUserActivityStatus = By.XPath(listUsersXPath + "//p[1]");

        private static string MainPanelXpath = "//main[contains(@class, 'AdminPanel')]";
        private readonly By ActiveButton = By.XPath(MainPanelXpath + "//span[contains(text(),'Active')]");
    }
}
