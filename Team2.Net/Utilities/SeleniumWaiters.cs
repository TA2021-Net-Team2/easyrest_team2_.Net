using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Team2.Net
{
    public static class SeleniumWaiters
    {
        public static void ShouldLocate(IWebDriver webDriver, string location)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(location));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Cannot find location: {location}", ex);
            }
        }

        public static void WaitSomeInterval(int seconds = 10)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static void WaitElement(IWebDriver webDriver, By locator, int seconds = 10)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

    }
}