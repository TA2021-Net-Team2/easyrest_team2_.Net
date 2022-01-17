using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class ClientPanel
    {
        private readonly By _identificateEmail = By.XPath("//*[contains(text(), 'katherinebrennan@test.com')]");
        private readonly By _buttonCurrentOrders = By.XPath("//span[contains (text(), 'Current Orders')]");
        private readonly By _buttonHistoryOrders = By.XPath("//span[contains (text(), 'Order History')]");
        private readonly By _tabHistory = By.CssSelector("a[href='/profile/order_history/History']");
        private readonly By _buttonShowMoreHistory = By.XPath("//div[@role = 'button'][1]");
        private readonly By _buttonReorderFromHistory = By.XPath("//span[text()= 'Reorder'][1]");
        private readonly By _identificateConfirmAllert = By.XPath("//p[text()= 'Order status changed to Waiting for confirm']");
        private readonly By _buttonSubmitFromHistory = By.XPath("//span[text()= 'Submit']");
        private readonly By _tabDeclined = By.CssSelector("a[href='/profile/order_history/Declined']");

        private readonly By _buttonAcceptedOrders = By.XPath("//span[contains (text(), 'Accepted')]");
        private readonly By _buttonShowList = By.XPath("//*//div[contains(@class, 'expandIcon')]");
        private readonly By _buttonAssignedWaiter = By.XPath("//span[contains (text(), 'Assigned waiter')]");
        private readonly By _buttonPressInProgress = By.XPath("//span[contains (text(), 'In progress')]");

        private readonly By _buttonRemoved = By.XPath("//span[contains (text(), 'Removed')]");
        private readonly By _buttonFailed = By.XPath("//span[contains (text(), 'Failed')]");

        private readonly By _tabDraft = By.XPath("//span[contains (text(), 'Draft')]");
        private readonly By _tabWaitingForConfirm = By.XPath("//span[contains (text(), 'Waiting for confirm')]");
        private readonly By _buttonDeclinefromWaiting = By.XPath("//span[text()= 'Decline'][1]");
        private readonly By _buttonDeletefromDraft = By.XPath("//span[text()= 'Delete'][1]");

        private readonly By _buttonShowLess = By.XPath("//div[contains(@class, 'expanded')]");

        private readonly By _deletedOrderButton = By.XPath("//p[contains (text(), 'Order deleted')]");
        private readonly By _declinedOrderButton = By.XPath("//p[contains (text(), 'Order declined')]");

        private readonly By _identificateSelected = By.XPath("//a[contains(@class, 'selected')]");
    }
}
