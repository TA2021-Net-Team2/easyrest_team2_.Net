using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class BasePage
    {
        //переписати
        protected readonly By UserMenuAvatar = By.XPath("/html/body/div/header/div/div/div/button");
        protected readonly By _signInButton = By.CssSelector("a[href='/log-in']");
        protected readonly By _signUpButton = By.CssSelector("a[href='/sign-up']");

        //переписати
        protected readonly By Header = By.CssSelector("/html/body/div/header");
        protected readonly By RestaurantListButton = By.CssSelector("a[href='/restaurants']");
    }
}
