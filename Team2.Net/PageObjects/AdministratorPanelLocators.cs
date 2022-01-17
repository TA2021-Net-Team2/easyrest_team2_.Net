using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class AdministratorPanel
    {
        // tabs
        private readonly By Assign_waiter_tab = By.XPath("span[text() = 'Assigned waiter'][1]");
        private readonly By Waiter_tab = By.XPath("//span[text() = 'Waiters']");
        private readonly By Accepted_tab = By.XPath("//span[text()='Accepted'][1]");
        // Arrows, buttons
        private readonly By ArrowDown = By.XPath("//div[contains(@class, 'expandIcon')][1]");
        private readonly By ArrowUp = By.XPath("//div[contains(@class, 'expanded')]");
        private readonly By Second_ArrowDown = By.XPath("//div[contains(@class, 'expandIcon')][1]//following::div[contains(@class, 'expandIcon')][1]");
        private readonly By Second_ArrowUp = By.XPath("//div[contains(@class, 'expandIcon')][1]//following::div[contains(@class, 'expanded')][1]");

        private readonly By Radiobutton = By.XPath("//input[@type='radio'][1]");
        private readonly By ActiveStatus = By.XPath("//button/span[contains(text(),'Assign')]");
        private readonly By Assign_waiter = By.XPath("//span[text() = 'Assign'][1]");
        // Checkers
        private readonly By Check_assign = By.XPath("//p[contains(text(), 'status changed to Assigned')]");
        private readonly By Check_accept = By.XPath("//p[contains(text(),'status changed to Accepted')]");
        private readonly By Error_assign = By.XPath("//p[contains(text(), 'Pls pick waiter')]");

    }
}
