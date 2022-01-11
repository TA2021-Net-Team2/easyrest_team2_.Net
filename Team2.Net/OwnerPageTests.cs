using System;
using System.Collections.Generic;
using System.Text;
using Team2.Net.PageObjects;
using NUnit.Framework;

namespace Team2.Net
{
    public class OwnerPageTests : BaseTest
    {
        private const string StartLoginOwner = "earlmorrison@test.com";
        private const string PasswordOwner = "1111";
        private const string restarauntName = "Matsuri";
        private const string restarauntAddress = "Village 8 street 999";
        private const string restarauntPhone = "380999999999";
        private const string restarauntText = "Good place";
        private const string secondText = "Good place";


        private MyRestaraunts _myRestaraunts;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            OwnerLogin();
            _myRestaraunts = new MyRestaraunts(_webDriver);
        }

        private void OwnerLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginOwner, PasswordOwner);
        }

        [Test]
        public void CreateOwnRestaraunt()
        {
            var pageMyRestaraunts = new MyRestaraunts(_webDriver);
            pageMyRestaraunts.AddNewRestaraunt(restarauntName,restarauntAddress,restarauntPhone,restarauntText,secondText);

            Assert.AreEqual("Restaurant was successfully created", _myRestaraunts.GetActivityStatusRestaraunt());
        }

        [Test]
        public void AddRestarauntToArchive()
        {
            var pageMyRestaraunts = new MyRestaraunts(_webDriver);
            pageMyRestaraunts.ArchiveRestaraunt();

            //Assert.AreEqual();
        }
        [Test]
        public void UnarchiveRestaraunt()
        {

        }
        [Test]
        public void EditRestarauntInformation()
        {

        }

    }
}
