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
        //private readonly By _progressButton = By.XPath("//span[contains(text(),'In progress')]//following::button[1]");
        
    }
}
