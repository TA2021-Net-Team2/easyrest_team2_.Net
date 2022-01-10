using OpenQA.Selenium;
using System;
using System.Threading;
using System.Text;

namespace Team2.Net.Utilities
{
    public static class ExplicitWaiters
    {
        private static int timeout = 5;

        //Перевірка тексту
        public static void WaitForTextEntered(IWebDriver webDriver, By elementXPath, string expectedValue)
        {
            long dateTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            while (true)
            {
                if (webDriver.FindElement(elementXPath).GetAttribute("value").Equals(expectedValue))
                {
                    return;
                }
                if (((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() >= dateTime + timeout)
                {
                    break;
                }
            }
            throw new Exception(message: $"Element path { elementXPath } \n" +
                $"'{webDriver.FindElement(elementXPath).GetAttribute("value")}' is not equal '{expectedValue}'");
        }

        //Перевірка довжини прихованого тексту 
        public static void WaitForCoveredTextEntered(IWebDriver webDriver, By elementXPath, string expectedValue)
        {
            long dateTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            while (true)
            {
                if (webDriver.FindElement(elementXPath).GetAttribute("value").Length.Equals(expectedValue.Length))
                {
                    return;
                }
                if (((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() >= dateTime + timeout)
                {
                    break;
                }
            }
            throw new Exception(message: $"Element path { elementXPath } \n" +
                $"'{webDriver.FindElement(elementXPath).GetAttribute("value").Length}' is not equal '{expectedValue.Length}'");
        }

        public static void WaitElementsDisplayed(IWebDriver webDriver, params By[] elementXPathes)
        {
            foreach(By elementXPath in elementXPathes)
            {
                if (!TryForElementDisplayed(webDriver, elementXPath))
                {
                    throw new Exception(message: $"Element path { elementXPath } \n" +
                        $"not displayed! ");
                }  
            }
        }

        public static void WaitElementDisplayed(IWebDriver webDriver, By elementXPath)
        {
            if (!TryForElementDisplayed(webDriver, elementXPath))
            {
                throw new Exception(message: $"Element path { elementXPath } \n" +
                    $"not displayed! ");
            }
        }

        public static bool TryForElementDisplayed(IWebDriver webDriver, By elementXPath)
        {
            long dateTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            while (true)
            {
                try
                {
                    if (webDriver.FindElement(elementXPath).Displayed)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {

                }

                if (((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() >= dateTime + timeout)
                {
                    break;
                }
            }
            return false;
        }
    }
}
