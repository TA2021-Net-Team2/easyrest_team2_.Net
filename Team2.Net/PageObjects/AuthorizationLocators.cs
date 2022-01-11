using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.Net.PageObjects
{
    public partial class Authorization
    {
        private readonly By _emailInputButton = By.XPath("//input[@name='email']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='password']");
        private readonly By _loginButton = By.XPath("//button[@type='submit']");
    }
}
