using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;
using OpenQA.Selenium;

namespace Team2.Net.PageObjects
{
    public partial class MyRestaraunts
    {
        private IWebDriver _webDriver;

        public MyRestaraunts(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public string GetActivityStatusRestaraunt()
        {
            return _webDriver.FindElement(statusAdded).Text;
        }
        public MyRestaraunts AddNewRestaraunt(string RestarauntName, string RestarauntAddress, string RestarauntPhone, string RestarauntText, string SecondText)
        {
            SeleniumWaiters.WaitSomeInterval(1);
            _webDriver.FindElement(AddRestarauntButton).Click();
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntNameFormInput).SendKeys(RestarauntName);
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntAdressFormInput).SendKeys(RestarauntAddress);
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntPhoneFormInput).SendKeys(RestarauntPhone);
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntTextFormInput).SendKeys(RestarauntText);
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntSelectMenuFormInput).Click();
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntTagPizzaFormInput).Click();
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntTagSushiFormInput).Click();
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntEmptyPlace).Click();
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(RestarauntTextDescriptionFormInput).SendKeys(SecondText);
            SeleniumWaiters.WaitSomeInterval(1);

            _webDriver.FindElement(AddButton).Click();
            SeleniumWaiters.WaitSomeInterval(1);

            return new MyRestaraunts(_webDriver);
        }
        public MyRestaraunts ArchiveRestaraunt()
        {
            SeleniumWaiters.WaitSomeInterval(1);
            _webDriver.FindElement(AdditionalButton).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            _webDriver.FindElement(ArchiveButton).Click();
            //bla
            return new MyRestaraunts(_webDriver); 
        }
    }
}
