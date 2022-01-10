using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;

        [SetUp]
        public virtual void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://localhost:3000/");
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public virtual void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
