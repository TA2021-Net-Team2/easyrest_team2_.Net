using System;
using System.Collections.Generic;
using System.Text;
using Team2.Net.PageObjects;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

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

        [Test(Description = "Owner log in")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test201_OwnerLogin() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=0
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        // Owner tests Meleshchuk

        [Test(Description = "Create restaurant")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test202_CreateOwnRestaurant() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=1382493327
        {
            string restarauntName = "Matsuri";
            string restarauntAddress = "Village 8 street 999";
            string restarauntPhone = "380999999999";
            string restarauntText = "Good place";
            string secondText = "Good place";

            _myRestaurants.AddNewRestaraunt(restarauntName, restarauntAddress, restarauntPhone, restarauntText, secondText);

            Assert.AreEqual("Restaurant was successfully created", _myRestaurants.GetActivityStatusRestaraunt());
        }

        [Test(Description = "Archive restaurant")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test203_ArchiveRestaurant() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=162147456
        {
            _myRestaurants.ArchiveRestaraunt();

            Assert.AreEqual("ARCHIVED", _myRestaurants.GetArchiveStatus());
        }

        [Test(Description = "Unarchcived restaurant")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test204_UnarchiveRestaurant() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=1130945254
        {
            _myRestaurants.UnrchiveRestaraunt();

            Assert.AreEqual("NOT APPROVED", _myRestaurants.GetUnarchiveStatus());
        }

        [Test(Description = "Owner log in")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test205_EditRestaurantInformation() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=1841087841
        {
            _myRestaurants.EditRestarauntInformation();

            Assert.AreEqual("Restaurant was successfully updated", _myRestaurants.GetEditStatusRestaraunt());
        }

        [Test(Description = "Edit object to menu")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test206_EditObjectToMenu() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=1785663944
        {
            _myRestaurants.EditObjectToMenu();

            Assert.AreEqual("There is nothing to eat", _myRestaurants.GetEditedObjectStatus());
        }

        [Test(Description = "Add new object to menu")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test207_AddNewObjectToMenu() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=571210351
        {
            _myRestaurants.AddNewObjectToMenu();

            //Assert.AreEqual();
        }

        [Test(Description = "Delete object")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test208_DeleteObjectToMenu() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=485463946
        {
            _myRestaurants.DeleteObjectToMenu();

            Assert.False(_myRestaurants.GetDeleteObjectStatus());
        }

        [Test(Description = "Create new list menu")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test209_CreateNewListMenu() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=1441213613
        {
            _myRestaurants.CreateNewListMenu();

            Assert.True(_myRestaurants.GetCreateNewListMenuStatus());
        }

        [Test(Description = "Create new image to list menu")]
        [AllureTag]
        [AllureOwner("Meleshchuk")]
        public void Test210_CreateNewImageListMenu() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=653648078
        {
            _myRestaurants.CreateNewImageListMenu();

            Assert.True(_myRestaurants.GetCreateNewImageMenuStatus());
        }

        // ****** Owner auto tests PART 2 by Bohdan Oleksiichuk ******

        [Test(Description = "Make menu primary")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test211_MakeMenuPrimary() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=629110417
        {
            _myRestaurants.MakeMenuPrimary();

            Assert.AreEqual("Make not primary", _myRestaurants.GetNotPrimaryStatus());
        }

        [Test(Description = "Make menu not primary")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test212_MakeMenuNotPrimary() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=708852740
        {
            _myRestaurants.MakeMenuNotPrimary();

            Assert.AreEqual("Make primary", _myRestaurants.GetPrimaryStatus());
        }

        [Test(Description = "Add waiter")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test213_AddWaiter() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=673161025
        {
            _myRestaurants.AddWaiter();

            Assert.AreEqual("User successfully added", _myRestaurants.GetSuccessStatusAdd());
        }

        [Test(Description = "Delete waiter")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test214_DeleteWaiter() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=1236731630
        {
            _myRestaurants.DeleteWaiter();

            Assert.False(_myRestaurants.GetFirstWaiter());
        }

        [Test(Description = "Add administrator")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test215_AddAdministrator() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=1637726513
        {
            _myRestaurants.AddAdministrator();

            Assert.AreEqual("User successfully added", _myRestaurants.GetSuccessStatusAdd());
        }

        [Test(Description = "Delete administrator")]
        [AllureTag]
        [AllureOwner("Oleksiichuk")]
        public void Test216_DeleteAdministrator() // https://docs.google.com/spreadsheets/d/1JE1W3-m7x_F-APVwvsBPQc-ho193H_6-FC9IwNNWkwY/edit#gid=29618741
        {
            _myRestaurants.DeleteAdministrator();

            Assert.False(_myRestaurants.GetFirstAdministrator());
        }
    }
}
