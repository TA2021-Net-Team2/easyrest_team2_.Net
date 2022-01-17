using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;
using OpenQA.Selenium;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;

namespace Team2.Net.PageObjects
{
    public partial class MyRestaurants
    {
        private IWebDriver _webDriver;

        public MyRestaurants(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            Actions actions = new Actions(_webDriver);
        }
        public string GetActivityStatusRestaraunt()
        {
            return _webDriver.FindElement(statusAdded).Text;
        }
        public string GetArchiveStatus()
        {
            return _webDriver.FindElement(StatusArchived).Text;
        }
        public string GetUnarchiveStatus()
        {
            return _webDriver.FindElement(StatusUnarchived).Text;
        }
        public string GetEditStatusRestaraunt()
        {
            return _webDriver.FindElement(statusEdited).Text;
        }
        public bool GetDeleteObjectStatus()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, PumpkinSoupCheck);
        }
        public string GetEditedObjectStatus()
        {
            return _webDriver.FindElement(statusEditedObject).Text;
        }
        public bool GetCreateNewImageMenuStatus()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, NotSimpleImageButton);
        }
        public bool GetCreateNewListMenuStatus()
        {
            return ExplicitWaiters.TryForElementDisplayed(_webDriver, SimpleListButton);
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

        public MyRestaurants AddNewRestaraunt(string RestarauntName, string RestarauntAddress, string RestarauntPhone, string RestarauntText, string SecondText)
        {
            SeleniumWaiters.WaitElement(_webDriver, AddRestarauntButton);
            _webDriver.FindElement(AddRestarauntButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, RestarauntNameFormInput);
            _webDriver.FindElement(RestarauntNameFormInput).SendKeys(RestarauntName);

            SeleniumWaiters.WaitElement(_webDriver, RestarauntAdressFormInput);
            _webDriver.FindElement(RestarauntAdressFormInput).SendKeys(RestarauntAddress);

            SeleniumWaiters.WaitElement(_webDriver, RestarauntPhoneFormInput);
            _webDriver.FindElement(RestarauntPhoneFormInput).SendKeys(RestarauntPhone);

            SeleniumWaiters.WaitElement(_webDriver, RestarauntTextFormInput);
            _webDriver.FindElement(RestarauntTextFormInput).SendKeys(RestarauntText);

            SeleniumWaiters.WaitElement(_webDriver, RestarauntSelectMenuFormInput);
            _webDriver.FindElement(RestarauntSelectMenuFormInput).Click();

            SeleniumWaiters.WaitElement(_webDriver, RestarauntTagPizzaFormInput);
            _webDriver.FindElement(RestarauntTagPizzaFormInput).Click();

            SeleniumWaiters.WaitElement(_webDriver, RestarauntTagSushiFormInput);
            _webDriver.FindElement(RestarauntTagSushiFormInput).Click();

            SeleniumWaiters.WaitElement(_webDriver, RestarauntEmptyPlace);
            _webDriver.FindElement(RestarauntEmptyPlace).Click();

            SeleniumWaiters.WaitElement(_webDriver, RestarauntTextDescriptionFormInput);
            _webDriver.FindElement(RestarauntTextDescriptionFormInput).SendKeys(SecondText);

            SeleniumWaiters.WaitElement(_webDriver, AddButton);
            _webDriver.FindElement(AddButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, statusAdded);

            return new MyRestaurants(_webDriver);
        }
        public MyRestaurants ArchiveRestaraunt()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForChapmanPLC);
            _webDriver.FindElement(AdditionalButtonForChapmanPLC).Click();

            SeleniumWaiters.WaitElement(_webDriver, ArchiveButton);
            _webDriver.FindElement(ArchiveButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, StatusArchived);

            return new MyRestaurants(_webDriver);
        }
        public MyRestaurants UnrchiveRestaraunt()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForChapmanPLC);
            _webDriver.FindElement(AdditionalButtonForChapmanPLC).Click();

            SeleniumWaiters.WaitElement(_webDriver, UnarchiveButton);
            _webDriver.FindElement(UnarchiveButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, StatusUnarchived);

            return new MyRestaurants(_webDriver);
        }
        public MyRestaurants EditRestarauntInformation()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForJohnsonPLC);
            _webDriver.FindElement(AdditionalButtonForJohnsonPLC).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, EditButton);
            _webDriver.FindElement(EditButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, EditDescription);
            _webDriver.FindElement(EditDescription).SendKeys(OpenQA.Selenium.Keys.Control + "A");

            SeleniumWaiters.WaitElement(_webDriver, EditDescription);
            _webDriver.FindElement(EditDescription).SendKeys("Bla bla bla");

            SeleniumWaiters.WaitElement(_webDriver, Submit);
            _webDriver.FindElement(Submit).Click();

            SeleniumWaiters.WaitElement(_webDriver, statusEdited);

            return new MyRestaurants(_webDriver);
        }
        public MyRestaurants EditObjectToMenu()
        {
            Actions actions = new Actions(_webDriver);

            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForTaylorInc);
            _webDriver.FindElement(AdditionalButtonForTaylorInc).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MenuesButton);
            _webDriver.FindElement(MenuesButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, CommonButton);
            _webDriver.FindElement(CommonButton).Click();

            SeleniumWaiters.WaitSomeInterval(2);

            IWebElement pk = _webDriver.FindElement(PersianLambCheck);
            actions.MoveToElement(pk).Perform();

            SeleniumWaiters.WaitElement(_webDriver, PersianLambEditButton);
            _webDriver.FindElement(PersianLambEditButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, PersianLambEditText);
            _webDriver.FindElement(PersianLambEditText).Click();
            _webDriver.FindElement(PersianLambEditText).SendKeys(OpenQA.Selenium.Keys.Control + "A");
            _webDriver.FindElement(PersianLambEditText).SendKeys("There is nothing to eat");

            SeleniumWaiters.WaitElement(_webDriver, PersianLambSaveButton);
            _webDriver.FindElement(PersianLambSaveButton).Click();

            SeleniumWaiters.WaitElement(_webDriver,statusEditedObject);

            return new MyRestaurants(_webDriver);
        }

        public MyRestaurants AddNewObjectToMenu()
        {
            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForTaylorInc);
            _webDriver.FindElement(AdditionalButtonForTaylorInc).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MenuesButton);
            _webDriver.FindElement(MenuesButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, CommonButton);
            _webDriver.FindElement(CommonButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, TextFormName);
            _webDriver.FindElement(TextFormName).SendKeys("Test");

            SeleniumWaiters.WaitElement(_webDriver, TextFormDescription);
            _webDriver.FindElement(TextFormDescription).SendKeys("Test");

            SeleniumWaiters.WaitElement(_webDriver, TextFormIngredients);
            _webDriver.FindElement(TextFormIngredients).SendKeys("Test, test");

            SeleniumWaiters.WaitElement(_webDriver, TextFormName);
            _webDriver.FindElement(TextFormName).SendKeys("Test");

            _webDriver.FindElement(TextFormAmount);
            _webDriver.FindElement(TextFormAmount).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);
            _webDriver.FindElement(TextFormAmount).SendKeys("1");

            _webDriver.FindElement(TextFormPrice);
            _webDriver.FindElement(TextFormPrice).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);
            _webDriver.FindElement(TextFormPrice).SendKeys("10.15");

            SeleniumWaiters.WaitElement(_webDriver, TextFormCategory);
            _webDriver.FindElement(TextFormCategory).Click();

            SeleniumWaiters.WaitElement(_webDriver, TextFormCategoryName);
            _webDriver.FindElement(TextFormCategoryName).Click();

            SeleniumWaiters.WaitElement(_webDriver, SelectPhotoList);
            _webDriver.FindElement(SelectPhotoList).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            System.Windows.Forms.SendKeys.SendWait("D:\\Test1.JPG");
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");

            SeleniumWaiters.WaitElement(_webDriver, AddMenuButton);
            _webDriver.FindElement(AddMenuButton).Click();

            return new MyRestaurants(_webDriver);
        }
        public MyRestaurants DeleteObjectToMenu()
        {
            Actions actions = new Actions(_webDriver);

            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForTaylorInc);
            _webDriver.FindElement(AdditionalButtonForTaylorInc).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MenuesButton);
            _webDriver.FindElement(MenuesButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, CommonButton);
            _webDriver.FindElement(CommonButton).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            IWebElement pk = _webDriver.FindElement(PumpkinSoupCheck);
            actions.MoveToElement(pk).Perform();

            SeleniumWaiters.WaitElement(_webDriver, DeletePumpkinSoup);
            _webDriver.FindElement(DeletePumpkinSoup).Click();

            SeleniumWaiters.WaitSomeInterval(2);

            return new MyRestaurants(_webDriver);
        }
        public MyRestaurants CreateNewListMenu()
        {

            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForTaylorInc);
            _webDriver.FindElement(AdditionalButtonForTaylorInc).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MenuesButton);
            _webDriver.FindElement(MenuesButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, CreateMenuButton);
            _webDriver.FindElement(CreateMenuButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, NameMenuFormInput);
            _webDriver.FindElement(NameMenuFormInput).SendKeys("Simple");

            SeleniumWaiters.WaitElement(_webDriver, NextButton);
            _webDriver.FindElement(NextButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, TextFormName);
            _webDriver.FindElement(TextFormName).SendKeys("Test");

            SeleniumWaiters.WaitElement(_webDriver, TextFormDescription);
            _webDriver.FindElement(TextFormDescription).SendKeys("Test");

            SeleniumWaiters.WaitElement(_webDriver, TextFormIngredients);
            _webDriver.FindElement(TextFormIngredients).SendKeys("Test, test");

            SeleniumWaiters.WaitElement(_webDriver, TextFormName);
            _webDriver.FindElement(TextFormName).SendKeys("Test");

            _webDriver.FindElement(TextFormAmount);
            _webDriver.FindElement(TextFormAmount).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);
            _webDriver.FindElement(TextFormAmount).SendKeys("1");

            _webDriver.FindElement(TextFormPrice);
            _webDriver.FindElement(TextFormPrice).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Home);
            _webDriver.FindElement(TextFormPrice).SendKeys("10.15");

            SeleniumWaiters.WaitElement(_webDriver, TextFormCategory);
            _webDriver.FindElement(TextFormCategory).Click();

            SeleniumWaiters.WaitElement(_webDriver, TextFormCategoryName);
            _webDriver.FindElement(TextFormCategoryName).Click();

            SeleniumWaiters.WaitElement(_webDriver, SelectPhotoList);
            _webDriver.FindElement(SelectPhotoList).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            System.Windows.Forms.SendKeys.SendWait("D:\\Test1.JPG");
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");

            SeleniumWaiters.WaitElement(_webDriver, NextListButton);
            _webDriver.FindElement(NextListButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, FinishListButton);
            _webDriver.FindElement(FinishListButton).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new MyRestaurants(_webDriver);
        }
        public MyRestaurants CreateNewImageListMenu()
        {
            Actions actions = new Actions(_webDriver);

            SeleniumWaiters.WaitElement(_webDriver, AdditionalButtonForTaylorInc);
            _webDriver.FindElement(AdditionalButtonForTaylorInc).Click();

            SeleniumWaiters.WaitElement(_webDriver, ManageButton);
            _webDriver.FindElement(ManageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, MenuesButton);
            _webDriver.FindElement(MenuesButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, CreateMenuButton);
            _webDriver.FindElement(CreateMenuButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, NameMenuFormInput);
            _webDriver.FindElement(NameMenuFormInput).SendKeys("Not simple");

            SeleniumWaiters.WaitElement(_webDriver, ImageMenuButton);
            _webDriver.FindElement(ImageMenuButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, NextButton);
            _webDriver.FindElement(NextButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, SelectPhoto);
            _webDriver.FindElement(SelectPhoto).Click();

            SeleniumWaiters.WaitSomeInterval(1);
            System.Windows.Forms.SendKeys.SendWait("D:\\Test1.JPG");
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");

            SeleniumWaiters.WaitElement(_webDriver, NextImageButton);
            _webDriver.FindElement(NextImageButton).Click();

            SeleniumWaiters.WaitElement(_webDriver, FinishImageButton);
            _webDriver.FindElement(FinishImageButton).Click();

            SeleniumWaiters.WaitSomeInterval(1);

            return new MyRestaurants(_webDriver);
        }

        // Autotests Bohdan Oleksiichuk

        public MyRestaurants MakeMenuPrimary()
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

            return new MyRestaurants(_webDriver);
        }

        public MyRestaurants MakeMenuNotPrimary()
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

            return new MyRestaurants(_webDriver);
        }

        public MyRestaurants AddWaiter()
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

            return new MyRestaurants(_webDriver);
        }

        public MyRestaurants DeleteWaiter()
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

            return new MyRestaurants(_webDriver);
        }

        public MyRestaurants AddAdministrator()
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

            return new MyRestaurants(_webDriver);
        }

        public MyRestaurants DeleteAdministrator()
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

            return new MyRestaurants(_webDriver);
        }
    }
}
