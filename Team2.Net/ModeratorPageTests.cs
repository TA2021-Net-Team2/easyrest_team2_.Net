using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Team2.Net;
using Team2.Net.PageObjects;

namespace Team2.Net
{
    public class ModeratorPageTests : BaseTest
    {
        private const string StartLoginModerator = "petermoderator@test.com";
        private const string PasswordModerator = "1";

        //Створи свій пейдж
        private ModeratorPanel _moderatorPanel;
        private BasePage _basePage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            ModeratorLogin();
            _moderatorPanel = new ModeratorPanel(_webDriver);
            _basePage = new BasePage(_webDriver);
        }

        private void ModeratorLogin() //301
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginModerator, PasswordModerator);
        }

        [Test]
        public void Test301_ModeratorLogin()
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test]
        public void Test303_ShowAllApruvedRestaurants() //303
        {
            _moderatorPanel.ShowAllApruvedRestaurants();

            Assert.AreEqual("Disapproved", _moderatorPanel.IdentificateDisapproved());
        }

        [Test]
        public void Test304_ShowAllUnapprovedRestaurants() //304
        {
            _moderatorPanel.ShowAllUnapprovedRestaurants();

            Assert.AreEqual("Approved", _moderatorPanel.IdentificateApproved());
        }

        [Test]
        public void Test305_DisapproveRestoran() //305
        {
            _moderatorPanel.DisapproveRestoran();

            Assert.AreEqual("Disapproved", _moderatorPanel.IdentificateDisapproved());
        }

        [Test]
        public void Test306_DisapproveArchivedRestourants() //306
        {
            _moderatorPanel.DisapproveArchivedRestourants();

            Assert.AreEqual("Approved", _moderatorPanel.IdentificateApproved());
        }

        [Test]
        public void Test307_ShowAllUsers() //307
        {
            _moderatorPanel.ShowAllUsers();

            Assert.AreEqual("Users", _moderatorPanel.IdentificateUsers());
        }

        [Test]
        public void Test308_ShowAllOwners() //308
        {
            _moderatorPanel.ShowAllOwners();

            Assert.AreEqual("Owners", _moderatorPanel.IdentificateOwners());
        }

        [Test]
        public void Test309_LockUsers() //309
        {
            _moderatorPanel.LockUser();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }

        [Test]
        public void Test310_LockOwner() //310
        {
            _moderatorPanel.LockOwner();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }

        [Test]
        public void Test311_UnLockUser() //311
        {
            _moderatorPanel.UnLockUser();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }

        [Test]
        public void Test312_UnLockOwner() //312
        {
            _moderatorPanel.UnLockOwner();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }
    }
}