﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Team2.Net.PageObjects
{
    public partial class MyRestaraunts
    {
        // ***** Locators by Serhii Meleshchuk *****

        private readonly By RestarauntNameFormInput = By.XPath("//input[@name='name']");
        private readonly By RestarauntAdressFormInput = By.XPath("//input[@name='address']");
        private readonly By RestarauntPhoneFormInput = By.XPath("//input[@name='phone']");
        private readonly By RestarauntTextFormInput = By.XPath("//textarea[@name='description']");
        private readonly By RestarauntSelectMenuFormInput = By.XPath("//div[contains(@class, 'selectMenu')]");
        private readonly By RestarauntTagPizzaFormInput = By.XPath("//*[contains(@data-value,'pizza')]");
        private readonly By RestarauntTagSushiFormInput = By.XPath("//*[contains(@data-value,'sushi')]");
        private readonly By RestarauntTextDescriptionFormInput = By.XPath("//*[contains(@id,'select-tags')]");
        private readonly By RestarauntEmptyPlace = By.XPath("//*[contains(@id,'menu-tags')]");
        private readonly By AddButton = By.XPath("//span[contains(text(),'Add')]");

        //Status
        private readonly By statusAdded = By.XPath("//p[contains(text(),'Restaurant was successfully created')]");
        private readonly By StatusArchived = By.XPath(ChapmanPLC + "//following::*[span='ARCHIVED']");
        private readonly By StatusUnarchived = By.XPath(ChapmanPLC + "//following::*[span='NOT APPROVED']");
        private readonly By statusEdited = By.XPath("//p[contains(text(),'Restaurant was successfully updated')]");

        //Restaraunts
        private static string ChapmanPLC = "//*[contains(h2,'Chapman PLC')]";
        private static string JohnsonPLC = "//*[contains(h2,'Johnson PLC')]";
        private static string TaylorInc = "//*[contains(h2,'Taylor Inc')]";

        //Buttons:
        //Additional buttons
        private readonly By AddRestarauntButton = By.XPath("//button[@title='Add restaurant']");

        private readonly By AdditionalButton = By.XPath("//button[contains(@aria-label,'More')]");
        private readonly By AdditionalButtonForChapmanPLC = By.XPath(ChapmanPLC + "//following::button[contains(@aria-label,'More')]");
        private readonly By AdditionalButtonForJohnsonPLC = By.XPath(JohnsonPLC + "//following::button[contains(@aria-label,'More')]");
        private readonly By AdditionalButtonForTaylorInc = By.XPath(TaylorInc + "//following::button[contains(@aria-label,'More')]");

        //Other buttons
        private readonly By ManageButton = By.XPath("//span[contains(text(),'Manage')]");
        private readonly By EditButton = By.XPath("//button[contains(@aria-label,'Show more')]");
        private readonly By EditDescription = By.XPath("//textarea[@name='description']");
        private readonly By Submit = By.XPath("//button[contains(@type,'submit')]");
        private readonly By MenuesButton = By.XPath("//span[contains(text(),'Menues')]");
        private readonly By CommonButton = By.XPath("//span[contains(text(),'Common')]");
        private readonly By ImageMenuButton = By.XPath("//span[contains(text(),'Image Menu')]");
        private readonly By CreateMenuButton = By.XPath("//span[contains(text(),'Create menu')]");

        private readonly By PumpkinSoup = By.XPath("/html/body/div/div/main/div/div[2]/table/tbody[2]/tr[6]");
        private readonly By MenuDeleteButton = By.XPath("/html/body/div/div/main/div/div[2]/table/tbody[2]/tr[5]/td[8]/div/button[1]");
        private readonly By MenuEditButton = By.XPath("/html/body/div/div/main/div/div[2]/table/tbody[2]/tr[6]/td[8]/div/button[2]");
        private readonly By PumpkinSoupEditText = By.XPath("/html/body/div/div/main/div/div[2]/table/tbody[2]/tr[6]/td[5]/div/div/textarea");
        private readonly By PumpkinSoupSaveButton = By.XPath("/html/body/div/div/main/div/div[2]/table/tbody[2]/tr[6]/td[1]/button");

        private readonly By PersianLamb = By.XPath("/html/body/div/div/main/div/div[2]/table/tbody[2]/tr[5]");

        //Archive / unarchive
        private readonly By ArchiveButton = By.XPath("//*[span='Archive']");
        private readonly By UnarchiveButton = By.XPath("//*[span='Unarchive']");

        //To add new object and create new list menu
        private readonly By TextFormName = By.XPath("//textarea[@name='name']");
        private readonly By TextFormDescription = By.XPath("//textarea[@name='description']");
        private readonly By TextFormIngredients = By.XPath("//textarea[@name='ingredients']");
        private readonly By TextFormAmount = By.XPath("//input[@name='amount']");
        private readonly By TextFormPrice = By.XPath("//input[@name='price']");
        private readonly By TextFormCategory = By.XPath("//select[@name='category']");
        private readonly By TextFormCategoryName = By.XPath("//select[@name='category']//following::option[contains(text(),'Soup')]");
        private readonly By AddMenuButton = By.XPath("//button[contains(@class,'primary')]");

        private readonly By NextListButton = By.XPath("//td[contains(@class, 'Table')]//following::span[contains(text(),'Next')][1]");
        private readonly By FinishListButton = By.XPath("//td[contains(@class, 'Table')]//following::span[contains(text(),'Finish')][last()]");

        private readonly By NameMenuFormInput = By.XPath("//input[@name='menuName']");

        private readonly By ImageButton = By.XPath("/html/body/div/div/main/div/form/div/div[1]/div/div/div/div/div/div[3]/div/div/label[2]");
        private readonly By SelectPhoto = By.XPath("//*[span='Select File']");

        private readonly By NextButton = By.XPath("//*[span='Next']");
        private readonly By NextImageButton = By.XPath("//div[contains(@class, 'ImageUploaderPresentational')]//following::span[contains(text(),'Next')][1]");
        private readonly By FinishImageButton = By.XPath("//div[contains(@class, 'ImageUploaderPresentational')]//following::span[contains(text(),'Finish')][2]");

        private readonly By SelectPhotoList = By.XPath("//div[contains(@class,'imgInput')]");


        // private readonly By Add_Button = By.XPath("//*/div/main/div/form/div/div[3]/div/div/div/div/div/div[2]/div/div[2]/table/tbody[1]/tr/td[1]/button/span[2]");

        // ***** Locators by Bohdan Oleksiichuk *****

        private static string titleRestaurantWithName = "//*[contains(text(),'Taylor Inc')]";

        // Restaurants additional buttons
        private readonly By AdditionalButtonTaylorIncRest = By.XPath(titleRestaurantWithName + "//following::button[contains(@aria-label,'More')]");

        // Manage buttons
        // Menues:

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
