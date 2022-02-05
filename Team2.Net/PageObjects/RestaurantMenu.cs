using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class RestaurantMenu
    {
        private IWebDriver _webDriver;


        public RestaurantMenu(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }
        public bool GetLocatorForm()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, OrderForm);
        }
        public RestaurantMenu CoctailAddToCart()
        {
            SeleniumWaiters.WaitElement(_webDriver, CoctailMenuInput);
            _webDriver.FindElement(CoctailMenuInput).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);

            SeleniumWaiters.WaitElement(_webDriver, CoctailMenuInput);
            _webDriver.FindElement(CoctailMenuInput).SendKeys("3");

            SeleniumWaiters.WaitElement(_webDriver, CoctailAddToCartButton);
            _webDriver.FindElement(CoctailAddToCartButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButton);
            _webDriver.FindElement(SubmitOrderButton).Click();

            return new RestaurantMenu(_webDriver);
        }
        public RestaurantMenu BakeryAddToCart()
        {
            SeleniumWaiters.WaitElement(_webDriver, BakeryMenuInput);
            _webDriver.FindElement(BakeryMenuInput).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);

            SeleniumWaiters.WaitElement(_webDriver, BakeryMenuInput);
            _webDriver.FindElement(BakeryMenuInput).SendKeys("3");

            SeleniumWaiters.WaitElement(_webDriver, BakeryAddToCartButton);
            _webDriver.FindElement(BakeryAddToCartButton).Click();

            return new RestaurantMenu(_webDriver);
        }
        public string FindSuccessButton()
        {
            SeleniumWaiters.WaitElement(_webDriver, SuccessText);
            return _webDriver.FindElement(SuccessText).Text;
        }
        public string FindSuccessButtonInWindow()
        {
            SeleniumWaiters.WaitElement(_webDriver, SuccessTextOrderButtonInWindow);
            return _webDriver.FindElement(SuccessTextOrderButtonInWindow).Text;
        }
        public string FindSuccessRemovingButton()
        {
            SeleniumWaiters.WaitElement(_webDriver, SuccessTextRemovingFromCart);
            return _webDriver.FindElement(SuccessTextRemovingFromCart).Text;
        }
        public RestaurantMenu SuccessOrderButton()
        {
            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButton);
            _webDriver.FindElement(SubmitOrderButton).Click();
            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButtonInWindow);
            _webDriver.FindElement(SubmitOrderButtonInWindow).Click();
            return new RestaurantMenu(_webDriver);
        }
        public RestaurantMenu CancelOrderButton()
        {
            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButton);
            _webDriver.FindElement(SubmitOrderButton).Click();
            SeleniumWaiters.WaitElement(_webDriver, CancelOrderButtonInWindow);
            _webDriver.FindElement(CancelOrderButtonInWindow).Click();
            return new RestaurantMenu(_webDriver);
        }
        public RestaurantMenu BakeryAddToCartThenRemove()
        {
            Actions actions = new Actions(_webDriver);
            SeleniumWaiters.WaitElement(_webDriver, BakeryMenuInput);
            _webDriver.FindElement(BakeryMenuInput).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);

            SeleniumWaiters.WaitElement(_webDriver, BakeryMenuInput);
            _webDriver.FindElement(BakeryMenuInput).SendKeys("3");

            SeleniumWaiters.WaitElement(_webDriver, BakeryAddToCartButton);
            _webDriver.FindElement(BakeryAddToCartButton).Click();
            SeleniumWaiters.WaitSomeInterval(2);
            IWebElement pk = _webDriver.FindElement(RemoveItemFromCart);
            actions.MoveToElement(pk).Perform();

            SeleniumWaiters.WaitElement(_webDriver, RemoveItemFromCart);
            _webDriver.FindElement(RemoveItemFromCart).Click();

            return new RestaurantMenu(_webDriver);
        }
        public RestaurantMenu RemoveOrderButton()
        {
            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButton);
            _webDriver.FindElement(SubmitOrderButton).Click();
            SeleniumWaiters.WaitElement(_webDriver, RemoveItemFromOrder);
            _webDriver.FindElement(RemoveItemFromOrder).Click();
            return new RestaurantMenu(_webDriver);
        }
        public RestaurantMenu DatePickerButton()
        {
            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButton);
            _webDriver.FindElement(SubmitOrderButton).Click();
            SeleniumWaiters.WaitElement(_webDriver, DatePickerButtonLabel);
            _webDriver.FindElement(DatePickerButtonLabel).Click();
            SeleniumWaiters.WaitElement(_webDriver, YearPicker);
            _webDriver.FindElement(YearPicker).Click();
            SeleniumWaiters.WaitElement(_webDriver, PickYear);
            _webDriver.FindElement(PickYear).Click();
            SeleniumWaiters.WaitElement(_webDriver, PickDay);
            _webDriver.FindElement(PickDay).Click();
            SeleniumWaiters.WaitElement(_webDriver, OKbutton);
            _webDriver.FindElement(OKbutton).Click();
            return new RestaurantMenu(_webDriver);
        }
        public RestaurantMenu TimePickerButton()
        {
            Actions actions = new Actions(_webDriver);
            SeleniumWaiters.WaitElement(_webDriver, SubmitOrderButton);
            _webDriver.FindElement(SubmitOrderButton).Click();
            SeleniumWaiters.WaitElement(_webDriver, TimePickerButtonLabel);
            _webDriver.FindElement(TimePickerButtonLabel).Click();
            //SeleniumWaiters.WaitElement(_webDriver, PickHour);
            SeleniumWaiters.WaitSomeInterval(1);
            IWebElement pk = _webDriver.FindElement(RemoveItemFromCart);
            actions.MoveToElement(pk).Perform();
            SeleniumWaiters.WaitElement(_webDriver, PickHour);
            _webDriver.FindElement(PickHour).Click();
            SeleniumWaiters.WaitElement(_webDriver, OKbutton);
            _webDriver.FindElement(OKbutton).Click();
            SeleniumWaiters.WaitElement(_webDriver, PickMinutes);
            _webDriver.FindElement(PickMinutes).Click();
            SeleniumWaiters.WaitElement(_webDriver, OKbutton);
            _webDriver.FindElement(OKbutton).Click();
            return new RestaurantMenu(_webDriver);
        }
        public string FindOKButton()
        {
            SeleniumWaiters.WaitElement(_webDriver, SuccessTextDateSet);
            return _webDriver.FindElement(SuccessTextDateSet).Text;
        }
    }
}