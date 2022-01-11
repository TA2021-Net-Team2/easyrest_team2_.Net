using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class BasePage
    {
        protected IWebDriver _webDriver;

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Waiters на те чи Аватар видно в разі авторизації користувача
        public bool IsAvatarVisible()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, UserMenuAvatar);
        }

        public Authorization SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();

            return new Authorization(_webDriver);
        }

        //Waiters на те чи панель Header видно в разі авторизації користувача (можливо воно і не потрібно)
        public virtual void IsPageLoaded()
        {
            ExplicitWaiters.WaitElementsDisplayed(_webDriver, Header);
        }

        public Registration Registration()
        {
            SeleniumWaiters.WaitSomeInterval(1);
            _webDriver.FindElement(_signUpButton).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            
            return new Registration(_webDriver);
        }

        public BasePage OpenRestaurantList()
        {
            _webDriver.FindElement(RestaurantListButton).Click();

            return new BasePage(_webDriver);
        }
    }
}
