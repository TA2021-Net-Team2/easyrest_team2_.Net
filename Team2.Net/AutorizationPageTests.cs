using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    [TestFixture("steveadmin@test.com", "1")]
    [TestFixture("earlmorrison@test.com", "1111")]
    public class AutorizationPageTests : BaseTest
    {
        private string StartLogin;
        private string Password;

        public AutorizationPageTests(string login, string password)
        {
            StartLogin = login;
            Password = password;
        }

        [Test]
        public void AuthorizationTest()
        {
            // Given
            var page = new BasePage(_webDriver);

            // When
            page
                .SignIn()
                .Login(StartLogin, Password);

            // Then
            Assert.True(page.IsAvatarVisible());
        }
    }
}