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

        // Owner auto tests PART 2 by Bohdan Oleksiichuk
        [Test]
        public void MakeMenuPrimaryTest()
        {
            _myRestaraunts.MakeMenuPrimary();

            Assert.AreEqual("Make not primary", _myRestaraunts.GetNotPrimaryStatus());
        }

        [Test]
        public void MakeMenuNotPrimaryTest()
        {
            _myRestaraunts.MakeMenuNotPrimary();

            Assert.AreEqual("Make primary", _myRestaraunts.GetPrimaryStatus());
        }

        [Test]
        public void AddWaiterTest()
        {
            _myRestaraunts.AddWaiter();

            Assert.AreEqual("User successfully added", _myRestaraunts.GetSuccessStatusAdd());
        }

        [Test]
        public void DeleteWaiterTest()
        {
            _myRestaraunts.DeleteWaiter();

            Assert.False(_myRestaraunts.GetFirstWaiter());
        }

        [Test]
        public void AddAdministratorTest()
        {
            _myRestaraunts.AddAdministrator();

            Assert.AreEqual("User successfully added", _myRestaraunts.GetSuccessStatusAdd());
        }

        [Test]
        public void DeleteAdministratorTest()
        {
            _myRestaraunts.DeleteAdministrator();

            Assert.False(_myRestaraunts.GetFirstAdministrator());
        }
    }
}
