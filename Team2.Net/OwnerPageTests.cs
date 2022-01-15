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

        // Owner tests Meleshchuk

        [Test]
        public void CreateOwnRestaraunt()
        {
            string restarauntName = "Matsuri";
            string restarauntAddress = "Village 8 street 999";
            string restarauntPhone = "380999999999";
            string restarauntText = "Good place";
            string secondText = "Good place";

            _myRestaraunts.AddNewRestaraunt(restarauntName, restarauntAddress, restarauntPhone, restarauntText, secondText);

            Assert.AreEqual("Restaurant was successfully created", _myRestaraunts.GetActivityStatusRestaraunt());
        }

        [Test]
        public void ArchiveRestaraunt()
        {
            _myRestaraunts.ArchiveRestaraunt();

            Assert.AreEqual("ARCHIVED", _myRestaraunts.GetArchiveStatus());
        }
        [Test]
        public void UnarchiveRestaraunt()
        {
            _myRestaraunts.UnrchiveRestaraunt();

            Assert.AreEqual("NOT APPROVED", _myRestaraunts.GetUnarchiveStatus());
        }
        [Test]
        public void EditRestarauntInformation()
        {
            _myRestaraunts.EditRestarauntInformation();

            Assert.AreEqual("Restaurant was successfully updated", _myRestaraunts.GetEditStatusRestaraunt());
        }
        [Test]
        public void EditListMenu()
        {
            _myRestaraunts.EditListMenu();

            //Assert.AreEqual("Restaurant was successfully updated", _myRestaraunts.GetEditStatusRestaraunt());
        }
        [Test]
        public void AddNewObjectToMenu()
        {
            _myRestaraunts.AddNewObjectToMenu();

            //Assert.AreEqual("Restaurant was successfully updated", _myRestaraunts.GetEditStatusRestaraunt());
        }
        [Test]
        public void DeleteObjectToMenu()
        {
            _myRestaraunts.DeleteObjectToMenu();

            //Assert.AreEqual("Restaurant was successfully updated", _myRestaraunts.GetEditStatusRestaraunt());
        }
        [Test]
        public void CreateNewListMenu()
        {
            _myRestaraunts.CreateNewListMenu();

            //Assert.AreEqual("Restaurant was successfully updated", _myRestaraunts.GetEditStatusRestaraunt());
        }
        [Test]
        public void CreateNewImageListMenu()
        {
            _myRestaraunts.CreateNewImageListMenu();

            //Assert.AreEqual("Restaurant was successfully updated", _myRestaraunts.GetEditStatusRestaraunt());
        }

        // ****** Owner auto tests PART 2 by Bohdan Oleksiichuk ******
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
