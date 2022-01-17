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

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            OwnerLogin();
            _myRestaurants = new MyRestaurants(_webDriver);
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
        public void CreateOwnRestaurantTest()
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
        public void ArchiveRestaurantTest()
        {
            _myRestaurants.ArchiveRestaraunt();

            Assert.AreEqual("ARCHIVED", _myRestaurants.GetArchiveStatus());
        }
        [Test]
        public void UnarchiveRestaurantTest()
        {
            _myRestaurants.UnrchiveRestaraunt();

            Assert.AreEqual("NOT APPROVED", _myRestaurants.GetUnarchiveStatus());
        }
        [Test]
        public void EditRestaurantInformationTest()
        {
            _myRestaurants.EditRestarauntInformation();

            Assert.AreEqual("Restaurant was successfully updated", _myRestaurants.GetEditStatusRestaraunt());
        }
        [Test]
        public void EditObjectToMenuTest()
        {
            _myRestaurants.EditObjectToMenu();

            Assert.AreEqual("There is nothing to eat", _myRestaurants.GetEditedObjectStatus());
        }
        [Test]
        public void AddNewObjectToMenuTest()
        {
            _myRestaurants.AddNewObjectToMenu();

            //Assert.AreEqual();
        }
        [Test]
        public void DeleteObjectToMenuTest()
        {
            _myRestaurants.DeleteObjectToMenu();

            Assert.False(_myRestaurants.GetDeleteObjectStatus());
        }
        [Test]
        public void CreateNewListMenuTest()
        {
            _myRestaurants.CreateNewListMenu();

            Assert.True(_myRestaurants.GetCreateNewListMenuStatus());
        }
        [Test]
        public void CreateNewImageListMenuTest()
        {
            _myRestaurants.CreateNewImageListMenu();

            Assert.True(_myRestaurants.GetCreateNewImageMenuStatus());
        }

        // ****** Owner auto tests PART 2 by Bohdan Oleksiichuk ******
        [Test]
        public void MakeMenuPrimaryTest()
        {
            _myRestaurants.MakeMenuPrimary();

            Assert.AreEqual("Make not primary", _myRestaurants.GetNotPrimaryStatus());
        }

        [Test]
        public void MakeMenuNotPrimaryTest()
        {
            _myRestaurants.MakeMenuNotPrimary();

            Assert.AreEqual("Make primary", _myRestaurants.GetPrimaryStatus());
        }

        [Test]
        public void AddWaiterTest()
        {
            _myRestaurants.AddWaiter();

            Assert.AreEqual("User successfully added", _myRestaurants.GetSuccessStatusAdd());
        }

        [Test]
        public void DeleteWaiterTest()
        {
            _myRestaurants.DeleteWaiter();

            Assert.False(_myRestaurants.GetFirstWaiter());
        }

        [Test]
        public void AddAdministratorTest()
        {
            _myRestaurants.AddAdministrator();

            Assert.AreEqual("User successfully added", _myRestaurants.GetSuccessStatusAdd());
        }

        [Test]
        public void DeleteAdministratorTest()
        {
            _myRestaurants.DeleteAdministrator();

            Assert.False(_myRestaurants.GetFirstAdministrator());
        }
    }
}
