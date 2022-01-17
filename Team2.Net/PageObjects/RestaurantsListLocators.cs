using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Team2.Net.Utilities;

namespace Team2.Net.PageObjects
{
    public partial class RestaurantsList
    {
        private static string titleRestaurantWithName = "//*[contains(text(),'Johnson PLC')]";

        private readonly By WatchMenu = By.XPath(titleRestaurantWithName + "//following::span[contains(text(),'Watch Menu')]");

        private readonly By avatarClientButton = By.XPath("//div[contains(@class, 'avatar')]");

        private readonly By avatarMyProfileButton = By.XPath("//a[contains(text(), 'My Profile')]");
        
    }
}
