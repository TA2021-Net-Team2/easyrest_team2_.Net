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

    }
}
