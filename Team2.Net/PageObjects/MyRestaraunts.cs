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

        public string GetPrimaryStatus()
        {
            return _webDriver.FindElement(MakePrimaryButton).Text;
        }

        public string GetNotPrimaryStatus()
        {
            return _webDriver.FindElement(MakeNotPrimaryButton).Text;
        }

        public string GetSuccessStatusAdd()
        {
            return _webDriver.FindElement(MessageSuccessfullyAdd).Text;
        }
        
        public bool GetFirstWaiter()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, SergioWaiterCheck);
        }
        public bool GetFirstAdministrator()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, MahidAdministratorCheck);
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

            return new MyRestaraunts(_webDriver); 
        }

        public MyRestaraunts MakeMenuPrimary()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonTaylorIncRest);
            _webDriver.FindElement(AdditionalButtonTaylorIncRest).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MenuesButton);
            _webDriver.FindElement(MenuesButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, FirstMenuButton);
            _webDriver.FindElement(FirstMenuButton).Click();
 
            SeleniumWaiters.WaitElement(_webDriver, AdditionalOptionsButton);
            _webDriver.FindElement(AdditionalOptionsButton).Click();
   
            SeleniumWaiters.WaitElement(_webDriver, MakePrimaryButton);
            _webDriver.FindElement(MakePrimaryButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, AdditionalOptionsButton);
            _webDriver.FindElement(AdditionalOptionsButton).Click();

            return new MyRestaraunts(_webDriver);
        }

        public MyRestaraunts MakeMenuNotPrimary()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonTaylorIncRest);
            _webDriver.FindElement(AdditionalButtonTaylorIncRest).Click();
            
            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();
            
            SeleniumWaiters.WaitElement(_webDriver, MenuesButton);
            _webDriver.FindElement(MenuesButton).Click();
            
            SeleniumWaiters.WaitElement(_webDriver, FirstMenuButton);
            _webDriver.FindElement(FirstMenuButton).Click();
            
            SeleniumWaiters.WaitElement(_webDriver, AdditionalOptionsButton);
            _webDriver.FindElement(AdditionalOptionsButton).Click();
            
            SeleniumWaiters.WaitElement(_webDriver, MakeNotPrimaryButton);
            _webDriver.FindElement(MakeNotPrimaryButton).Click();
           
            SeleniumWaiters.WaitElement(_webDriver, AdditionalOptionsButton);
            _webDriver.FindElement(AdditionalOptionsButton).Click();

            return new MyRestaraunts(_webDriver);
        }

        public MyRestaraunts AddWaiter()
        {
            string nameInput = "Sergio";
            string emailInput = "potatovich@mail.com";
            string passwordInput = "WorldQ123";
            string phoneNumberInput = "+380999999999";

            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonTaylorIncRest);
            _webDriver.FindElement(AdditionalButtonTaylorIncRest).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, WaitersButton);
            _webDriver.FindElement(WaitersButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, AddWaiterButton);
            _webDriver.FindElement(AddWaiterButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, NameInput);
            _webDriver.FindElement(NameInput).SendKeys(nameInput);

            SeleniumWaiters.WaitElement(_webDriver, MailInput);
            _webDriver.FindElement(MailInput).SendKeys(emailInput);

            SeleniumWaiters.WaitElement(_webDriver, PasswordInput);
            _webDriver.FindElement(PasswordInput).SendKeys(passwordInput);

            SeleniumWaiters.WaitElement(_webDriver, PhoneNumberInput);
            _webDriver.FindElement(PhoneNumberInput).SendKeys(phoneNumberInput);

            SeleniumWaiters.WaitElement(_webDriver, AddEndButton);
            _webDriver.FindElement(AddEndButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MessageSuccessfullyAdd);

            return new MyRestaraunts(_webDriver);
        }

        public MyRestaraunts DeleteWaiter()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonTaylorIncRest);
            _webDriver.FindElement(AdditionalButtonTaylorIncRest).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, WaitersButton);
            _webDriver.FindElement(WaitersButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, DeleteFirstWaiter);
            _webDriver.FindElement(DeleteFirstWaiter).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new MyRestaraunts(_webDriver);
        }

        public MyRestaraunts AddAdministrator()
        {
            string nameInput = "Mahid";
            string emailInput = "mahid@mail.com";
            string passwordInput = "WorldQ123";
            string phoneNumberInput = "+380999999999";

            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonTaylorIncRest);
            _webDriver.FindElement(AdditionalButtonTaylorIncRest).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, AdministratorButton);
            _webDriver.FindElement(AdministratorButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, AddAdministratorButton);
            _webDriver.FindElement(AddAdministratorButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, NameInput);
            _webDriver.FindElement(NameInput).SendKeys(nameInput);

            SeleniumWaiters.WaitElement(_webDriver, MailInput);
            _webDriver.FindElement(MailInput).SendKeys(emailInput);

            SeleniumWaiters.WaitElement(_webDriver, PasswordInput);
            _webDriver.FindElement(PasswordInput).SendKeys(passwordInput);

            SeleniumWaiters.WaitElement(_webDriver, PhoneNumberInput);
            _webDriver.FindElement(PhoneNumberInput).SendKeys(phoneNumberInput);

            SeleniumWaiters.WaitElement(_webDriver, AddEndButton);
            _webDriver.FindElement(AddEndButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MessageSuccessfullyAdd);

            return new MyRestaraunts(_webDriver);
        }

        public MyRestaraunts DeleteAdministrator()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonTaylorIncRest);
            _webDriver.FindElement(AdditionalButtonTaylorIncRest).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, AdministratorButton);
            _webDriver.FindElement(AdministratorButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, DeleteFirstAdministrator);
            _webDriver.FindElement(DeleteFirstAdministrator).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new MyRestaraunts(_webDriver);
        }
    }
}
