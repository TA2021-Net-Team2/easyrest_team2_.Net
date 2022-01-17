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
        private readonly By MenuInput = By.XPath("//input[contains(@class,'input')]");
        private readonly By AddToCartButton = By.XPath("//button[contains(@aria-label, 'Add to cart')]");

		//private readonly By CoctailName = By.XPath("//span[contains(text(),'Jamaican ginger beer & pineapple bundt cake')]");

		private static string CoctailName = "//*[contains(text(),'Jamaican ginger beer & pineapple bundt cake')]";
        private static string BakeryName = "//*[contains(text(),'Chicken')]";
        private static string DatePickerModalWindow = "//div[contains(@class, 'PickersModal')]";

        private readonly By CoctailMenuInput = By.XPath(CoctailName + "//following::input[contains(@type,'number')]");
        private readonly By CoctailAddToCartButton = By.XPath(CoctailName + "//following::button[contains(@aria-label, 'Add to cart')]");
        private readonly By BakeryMenuInput = By.XPath(BakeryName + "//following::input[contains(@type,'number')]");
        private readonly By BakeryAddToCartButton = By.XPath(BakeryName + "//following::button[contains(@aria-label, 'Add to cart')]");
        private readonly By SubmitOrderButton = By.XPath("//span[contains(text(), 'Submit order')]");
		private readonly By SuccessText = By.XPath("//p[contains (text(), 'Item was added')]");
        //private readonly By SuccessTextOrderButton = By.XPath("//p[contains (text(), 'Item was added')]");
        private readonly By SubmitOrderButtonInWindow = By.XPath("//span[text()= 'Submit']");
        private readonly By CancelOrderButtonInWindow = By.XPath("//span[text()= 'Cancel']");
		private readonly By SuccessTextOrderButtonInWindow = By.XPath("//p[contains (text(), 'Order status changed to Waiting for confirm')]");
        private readonly By RemoveItemFromCart = By.XPath("//button[@aria-label='Remove item']");
        private readonly By SuccessTextRemovingFromCart = By.XPath("//p[contains (text(), 'Item was removed')]");
        private readonly By RemoveItemFromOrder = By.XPath("//button[@class='MuiButtonBase-root-106 MuiIconButton-root-262']");
        private readonly By DatePickerButtonLabel = By.XPath("//label[text()= 'Date picker']");
        private readonly By YearPicker = By.XPath(DatePickerModalWindow + "//h6[contains(@class, 'subtitle')]");
		private readonly By PickYear = By.XPath(DatePickerModalWindow + "//div[contains(text(),'2022')]");
        private readonly By ScrollMonth = By.XPath("//button[@class='MuiButtonBase-root-106 MuiIconButton-root-262']");
        //private readonly By DatePickerYear = By.XPath(DatePickerModalWindow + "//h6[contains(@class, 'subtitle')]");
        //private readonly By DatePickerSelectYear = By.XPath(DatePickerModalWindow + "//div[contains(text(),'1970')]");
        //private readonly By DatePickerOkButton = By.XPath(DatePickerModalWindow + "//span[contains(text(),'OK')]");
    }
}
