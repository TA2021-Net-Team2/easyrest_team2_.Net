using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class ModeratorPanel
    {
        //    private readonly By _usersListButton = By.CssSelector("a[href='/admin/users']");
        //    private readonly By _ownersListButton = By.CssSelector("a[href='/admin/owners']");
        //    private readonly By _moderatorsListButton = By.CssSelector("a[href='/admin/moderators']");
        //    private readonly By _restaurantsListButton = By.CssSelector("a[href='/admin/restaurants']");

        //    private static string listUsersXPath = MainPanelXpath + "//table[contains(@class, 'Users-table')]";
        //    private readonly By listUsers = By.XPath(listUsersXPath);
        //    private readonly By FirstUserButtonLock = By.XPath(listUsersXPath + "//button[1]");
        //    private readonly By FirstUserActivityStatus = By.XPath(listUsersXPath + "//p[1]");

        //    private static string MainPanelXpath = "//main[contains(@class, 'AdminPanel')]";
        //    private readonly By ActiveButton = By.XPath(MainPanelXpath + "//span[contains(text(),'Active')]");
        //
       // private readonly By _signinButton = By.XPath("//*[@id=root]/header/div/div/div/a[1]/span[1]");
        //private readonly By 
        private readonly By _allAprovedButton = By.XPath("//span[contains (text(), 'Approved')][1]");
        private readonly By _allAproveDeletedButton = By.XPath("//span[contains (text(), 'Delete')][1]");
        private readonly By _disapprovedAllert = By.XPath("//p[contains (text(), 'Disapproved')]");

        private readonly By _allUnapprovedButton = By.XPath("//span[contains(text(),'Unapproved')][1]");
        private readonly By _allUnapprovedApproveButton = By.XPath("//span[text()='Approve']");
        private readonly By _approvedAllert = By.XPath("//p[contains (text(), 'Approved')]");

        private readonly By _allUnaprovedButton = By.XPath("//span[contains(text(),'Unapproved')][1]");
        private readonly By _allUnapprovedDisapproveButton = By.XPath("//span[text() = 'Disapprove']");
        private readonly By _disaprovedAllert = By.XPath("//p[text() = 'Disapproved']");

        private readonly By _allArchivedButton = By.XPath("//span[text() = 'Archived']");
        private readonly By _allArchivedRestoreButton = By.XPath("//span[text() = 'Restore']");
        private readonly By _aprovedAllert = By.XPath("//p[text() = 'Approved']");

        private readonly By _allUsersButton = By.XPath("//span[text() = 'Users']");

        private readonly By _allOwnersButton = By.XPath("//span[text() = 'Owners']");

        private readonly By _allUsersButtonn = By.XPath("//span[text()=  'Users']");
        private readonly By _lockButton = By.XPath("//button[contains(@class,  'colorPrimary')][1]");
        private readonly By _successAllert = By.XPath("//p[contains(text(),  'success')]");

        private readonly By _allOwnersLockButton  = By.XPath("//span[text()='Owners']");
        //private readonly By _lockOwnerButton = By.XPath("//button[contains(@class,  'colorPrimary')][1]");
        private readonly By _successAllertOwner = By.XPath("//*[local-name()='svg']/*[local-name()='path' and contains(@d,'M12 17c1')]//ancestor::button");

        private readonly By _allUsersButonn = By.XPath("//span[text()=  'Users']");
        private readonly By _bannedButton = By.XPath("//span[contains(text(),'Banned')]");
        private readonly By _unLockButton = By.XPath("//button[contains(@class,  'colorSecondary')]");
        private readonly By _successUnlockAllert = By.XPath("//p[contains(text(),  'success')]");

        private readonly By _allOwnerButton = By.XPath("//span[contains(text(),'Owners')]");
        //private readonly By _bannedButton = By.XPath("//span[contains(text(),'Banned')]");

        //private readonly By _successUnlockAllert = By.XPath("//p[contains(text(),  'success')]");
    }
    
}
