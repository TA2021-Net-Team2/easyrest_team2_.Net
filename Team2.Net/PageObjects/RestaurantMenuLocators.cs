using OpenQA.Selenium;
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

        private static string CoctailName  = "//*[contains(text(),'Jamaican ginger beer & pineapple bundt cake')]";

        private readonly By CoctailMenuInput = By.XPath(CoctailName + "//following::input[contains(@type,'number')]");
        private readonly By CoctailAddToCartButton = By.XPath(CoctailName + "//following::button[contains(@aria-label, 'Add to cart')]");
        private readonly By SubmitOrderButton = By.XPath("//span[contains(text(), 'Submit order')]");
    }
}
