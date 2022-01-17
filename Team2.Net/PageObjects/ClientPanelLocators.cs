using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team2.Net.PageObjects
{
	public partial class ClientPanel
	{
		private static string titleRestaurantWithName = "//*[contains(text(),'Johnson PLC')]";

		private readonly By WatchMenu = By.XPath(titleRestaurantWithName + "//following::span[contains(text(),'Watch Menu')]");
	}
}
