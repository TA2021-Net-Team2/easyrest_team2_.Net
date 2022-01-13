using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class WaiterPanel
    {
        private readonly By _linkInProgress = By.CssSelector("a[href='/waiter/orders/In progress']");
        private readonly By _linkAssignedWaiters = By.CssSelector("a[href='/waiter/orders/Assigned waiter']");
        private readonly By _buttonShowMore = By.XPath("//button[@aria-label = 'Show more'][1]");
        private readonly By _buttonClose = By.XPath("//button[1]/span[contains(text(),'Close order')]");
        private readonly By _buttonOrder = By.XPath("//button[1]/span[contains(text(),'Start order')]");
        private readonly By _progressButton = By.XPath("//span[text()= 'In progress']//following::button[1]");
        private readonly By _waiterButton = By.XPath("//span[text()= 'Assigned waiter']//following::button[1]");
        private readonly By successButton = By.XPath("//p[contains (text(), 'success')]");

    }
}
