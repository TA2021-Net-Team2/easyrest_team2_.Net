using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class ModeratorPanel
    {
        private IWebDriver _webDriver;

        public ModeratorPanel(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string IdentificateDisapproved()
        {
            return _webDriver.FindElement(_disapprovedAllert).Text;
        }

        public string IdentificateApproved()
        {
            return _webDriver.FindElement(_approvedAllert).Text;
        }

        public string IdentificateDissapproved()
        {
            return _webDriver.FindElement(_disapprovedAllert).Text;
        }

        public string IdentificateUsers()
        {
            return _webDriver.FindElement(_allUsersButton).Text;
        }

        public string IdentificateOwners()
        {
            return _webDriver.FindElement(_allOwnersButton).Text;
        }

        public string IdentificateSuccess()
        {
            return _webDriver.FindElement(_successAllert).Text;
        }

        public string IdentificateOwnerSuccess()
        {
            return _webDriver.FindElement(_successAllertOwner).Text;
        }
        public string IdentificateSuccessUnlockUser()
        {
            return _webDriver.FindElement(_successUnlockAllert).Text;
        }
        public string IdentificateSuccessUnlockOwner()
        {
            return _webDriver.FindElement(_successUnlockAllert).Text;
        }

        public ModeratorPanel ShowAllApruvedRestaurants()
        {
            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allAprovedButton);
            _webDriver.FindElement(_allAprovedButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allAproveDeletedButton);
            _webDriver.FindElement(_allAproveDeletedButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _disapprovedAllert);

            return new ModeratorPanel(_webDriver);
        }
        public ModeratorPanel ShowAllUnapprovedRestaurants()
        {
            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allUnapprovedButton);
            _webDriver.FindElement(_allUnapprovedButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allUnapprovedApproveButton);
            _webDriver.FindElement(_allUnapprovedApproveButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _approvedAllert);

            return new ModeratorPanel(_webDriver);
        }

        public ModeratorPanel DisapproveRestoran()
        {
            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allUnapprovedButton);
            _webDriver.FindElement(_allUnapprovedButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allUnapprovedDisapproveButton);
            _webDriver.FindElement(_allUnapprovedDisapproveButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _disapprovedAllert);

            return new ModeratorPanel(_webDriver);
        }

        public ModeratorPanel DisapproveArchivedRestourants()
        {
            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allArchivedButton);
            _webDriver.FindElement(_allArchivedButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allArchivedRestoreButton);
            _webDriver.FindElement(_allArchivedRestoreButton).Click();

            ExplicitWaiters.WaitElementDisplayed(_webDriver, _approvedAllert);

            return new ModeratorPanel(_webDriver);
        }

        public ModeratorPanel ShowAllUsers()
        {
            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allUsersButton);
            _webDriver.FindElement(_allUsersButton).Click();

            return new ModeratorPanel(_webDriver);
        }

        public ModeratorPanel ShowAllOwners()
        {
            ExplicitWaiters.WaitElementDisplayed(_webDriver, _allOwnersButton);
            _webDriver.FindElement(_allOwnersButton).Click();

            return new ModeratorPanel(_webDriver);
        }

        public ModeratorPanel LockUser()
        {
            SeleniumWaiters.WaitElement(_webDriver, _allUsersButton);
            _webDriver.FindElement(_allUsersButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _lockButton);
            _webDriver.FindElement(_lockButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _successAllert);

            return new ModeratorPanel(_webDriver);
        }
        public ModeratorPanel LockOwner()
        {
            SeleniumWaiters.WaitElement(_webDriver, _allOwnersLockButton);
            _webDriver.FindElement(_allOwnersLockButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _lockButton);
            _webDriver.FindElement(_lockButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _successAllert);

            return new ModeratorPanel(_webDriver);
        }
        public ModeratorPanel UnLockUser()
        {
            SeleniumWaiters.WaitElement(_webDriver, _allUsersButton);
            _webDriver.FindElement(_allUsersButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _bannedButton);
            _webDriver.FindElement(_bannedButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _unLockButton);
            _webDriver.FindElement(_unLockButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _successUnlockAllert);

            return new ModeratorPanel(_webDriver);
        }
        public ModeratorPanel UnLockOwner()
        {
            SeleniumWaiters.WaitElement(_webDriver, _allOwnersButton);
            _webDriver.FindElement(_allOwnersButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _bannedButton);
            _webDriver.FindElement(_bannedButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _unLockButton);
            _webDriver.FindElement(_unLockButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, _successUnlockAllert);

            return new ModeratorPanel(_webDriver);
        }
    }

}
