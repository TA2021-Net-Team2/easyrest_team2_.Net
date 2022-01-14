using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Team2.Net.PageObjects
{
    public partial class MyRestaraunts
    {
        private readonly By AddRestarauntButton = By.XPath("//button[@title='Add restaurant']");

        private readonly By RestarauntNameFormInput = By.XPath("//input[@name='name']");
        private readonly By RestarauntAdressFormInput = By.XPath("//input[@name='address']");
        private readonly By RestarauntPhoneFormInput = By.XPath("//input[@name='phone']");
        private readonly By RestarauntTextFormInput = By.XPath("//textarea[@name='description']");
        private readonly By RestarauntSelectMenuFormInput = By.XPath("//div[contains(@class, 'selectMenu')]");
        private readonly By RestarauntTagPizzaFormInput = By.XPath("//*[contains(@data-value,'pizza')]");
        private readonly By RestarauntTagSushiFormInput = By.XPath("//*[contains(@data-value,'sushi')]");
        private readonly By RestarauntTextDescriptionFormInput = By.XPath("/html/body/div/main/div/div/div/div[1]/div[3]/div/div/div/div[2]/form/div/div[7]/div/div[2]/div/div/div/div");
        private readonly By RestarauntEmptyPlace = By.XPath("/html/body/div[2]/div[1]");
        private readonly By AddButton = By.XPath("//span[contains(text(),'Add')]");

        private readonly By statusAdded = By.XPath("//p[contains(text(),'Restaurant was successfully created')]");

        //private readonly By AdditionalButton = By.XPath("//*/main/div/div/div/div[1]/div[1]/div[1]/div/div[2]/div/div[1]/button");
        //private readonly By ManageButton = By.XPath("//a[href='/profile/restaurants/1/edit/info']");

        private readonly By ArchiveButton = By.XPath("//*[span='Archive']");

        //Locators by Bohdan
        private static string titleRestaurantWithName = "//*[contains(text(),'Taylor Inc')]";

        private readonly By AdditionalButton = By.XPath("//button[contains(@aria-label,'More')]");
        private readonly By ManageButton = By.XPath("//span[contains(text(),'Manage')]");

        // Restaurants additional buttons
        private readonly By AdditionalButtonTaylorIncRest = By.XPath(titleRestaurantWithName + "//following::button[contains(@aria-label,'More')]");

        // Manage buttons
        // Menues:
        private readonly By MenuesButton = By.XPath("//span[contains(text(),'Menues')]");
        private readonly By FirstMenuButton = By.XPath("//a[contains(@class, 'DrawerMenu-nested')][1]");
        private readonly By AdditionalOptionsButton = By.XPath("//button[contains(@aria-label,'Action')]");

        // Menues:
        private readonly By WaitersButton = By.XPath("//span[contains(text(),'Waiters')]");
        private readonly By AddWaiterButton = By.XPath("//button[contains(@title,'Add Waiter')]");

        private readonly By AdministratorButton = By.XPath("//span[contains(text(),'Administrators')]");
        private readonly By AddAdministratorButton = By.XPath("//button[contains(@title,'Add Administrator')]");

        // Add waiters inputs and button
        private readonly By NameInput = By.XPath("//input[@name='name']");
        private readonly By MailInput = By.XPath("//input[@name='email']");
        private readonly By PasswordInput = By.XPath("//input[@name='password']");
        private readonly By PhoneNumberInput = By.XPath("//input[@name='phone_number']");
        private readonly By AddEndButton = By.XPath("//span[contains(text(),'Add')]");

        private readonly By MessageSuccessfullyAdd = By.XPath("//p[contains(text(),'User successfully added')]");

        // Primary buttons
        private readonly By MakePrimaryButton = By.XPath("//span[contains(text(),'Make primary')]");
        private readonly By MakeNotPrimaryButton = By.XPath("//span[contains(text(),'Make not primary')]");

        // Select waiter
        private static string WaiterSergio = "//span[contains(text(),'Sergio')]";

        private readonly By SergioWaiterCheck = By.XPath("//span[contains(text(),'Sergio')]");
        private readonly By DeleteFirstWaiter = By.XPath(WaiterSergio + "//following::button[contains(@class, 'ButtonBase')][1]");

        // Select administrator
        private static string AdministratorMahid = "//span[contains(text(),'Mahid')]";

        private readonly By MahidAdministratorCheck = By.XPath("//span[contains(text(),'Mahid')]");
        private readonly By DeleteFirstAdministrator = By.XPath(AdministratorMahid + "//following::button[contains(@class, 'ButtonBase')][1]");
    }
}
