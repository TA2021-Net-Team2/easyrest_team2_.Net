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

        private MyRestaurants _myRestaurants;
        private BasePage _basePage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            OwnerLogin();
            _myRestaurants = new MyRestaurants(_webDriver);
            _basePage = new BasePage(_webDriver);
        }

        private void OwnerLogin()
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginOwner, PasswordOwner);
        }

        [Test]
        public void Test201_OwnerLogin()
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        // Owner tests Meleshchuk

        [Test]
        public void Test202_CreateOwnRestaurant()
        {
            string restarauntName = "Matsuri";
            string restarauntAddress = "Village 8 street 999";
            string restarauntPhone = "380999999999";
            string restarauntText = "Good place";
            string secondText = "Good place";

            _myRestaurants.AddNewRestaraunt(restarauntName, restarauntAddress, restarauntPhone, restarauntText, secondText);

            Assert.AreEqual("Restaurant was successfully created", _myRestaurants.GetActivityStatusRestaraunt());
        }

        [Test]
        public void Test203_ArchiveRestaurant()
        {
            _myRestaurants.ArchiveRestaraunt();

            Assert.AreEqual("ARCHIVED", _myRestaurants.GetArchiveStatus());
        }

        [Test]
        public void Test204_UnarchiveRestaurant()
        {
            _myRestaurants.UnrchiveRestaraunt();

            Assert.AreEqual("NOT APPROVED", _myRestaurants.GetUnarchiveStatus());
        }

        [Test]
        public void Test205_EditRestaurantInformation()
        {
            _myRestaurants.EditRestarauntInformation();

            Assert.AreEqual("Restaurant was successfully updated", _myRestaurants.GetEditStatusRestaraunt());
        }

        [Test]
        public void Test206_EditObjectToMenu()
        {
            _myRestaurants.EditObjectToMenu();

            Assert.AreEqual("There is nothing to eat", _myRestaurants.GetEditedObjectStatus());
        }

        [Test]
        public void Test207_AddNewObjectToMenu()
        {
            _myRestaurants.AddNewObjectToMenu();

            //Assert.AreEqual();
        }

        [Test]
        public void Test208_DeleteObjectToMenu()
        {
            _myRestaurants.DeleteObjectToMenu();

            Assert.False(_myRestaurants.GetDeleteObjectStatus());
        }

        [Test]
        public void Test209_CreateNewListMenu()
        {
            _myRestaurants.CreateNewListMenu();

            Assert.True(_myRestaurants.GetCreateNewListMenuStatus());
        }

        [Test]
        public void Test210_CreateNewImageListMenu()
        {
            _myRestaurants.CreateNewImageListMenu();

            Assert.True(_myRestaurants.GetCreateNewImageMenuStatus());
        }

        // ****** Owner auto tests PART 2 by Bohdan Oleksiichuk ******

        [Test]
        public void Test211_MakeMenuPrimary()
        {
            _myRestaurants.MakeMenuPrimary();

            Assert.AreEqual("Make not primary", _myRestaurants.GetNotPrimaryStatus());
        }

        [Test]
        public void Test212_MakeMenuNotPrimary()
        {
            _myRestaurants.MakeMenuNotPrimary();

            Assert.AreEqual("Make primary", _myRestaurants.GetPrimaryStatus());
        }

        [Test]
        public void Test213_AddWaiter()
        {
            _myRestaurants.AddWaiter();

            Assert.AreEqual("User successfully added", _myRestaurants.GetSuccessStatusAdd());
        }

        [Test]
        public void Test214_DeleteWaiter()
        {
            _myRestaurants.DeleteWaiter();

            Assert.False(_myRestaurants.GetFirstWaiter());
        }

        [Test]
        public void Test215_AddAdministrator()
        {
            _myRestaurants.AddAdministrator();

            Assert.AreEqual("User successfully added", _myRestaurants.GetSuccessStatusAdd());
        }

        [Test]
        public void Test216_DeleteAdministrator()
        {
            _myRestaurants.DeleteAdministrator();

            Assert.False(_myRestaurants.GetFirstAdministrator());
        }
    }
}
