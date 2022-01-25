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

        private void ModeratorLogin() 
        {
            var page = new BasePage(_webDriver);
            page
                .SignIn()
                .Login(StartLoginModerator, PasswordModerator);
        }

        [Test]
        public void Test301_ModeratorLogin() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=1682771276
        {
            Assert.True(_basePage.IsAvatarVisible());
        }

        [Test]
        public void Test303_ShowAllApruvedRestaurants() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=672999615
        {
            _moderatorPanel.ShowAllApruvedRestaurants();

            Assert.AreEqual("Disapproved", _moderatorPanel.IdentificateDisapproved());
        }

        [Test]
        public void Test304_ShowAllUnapprovedRestaurants() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=111305378
        {
            _moderatorPanel.ShowAllUnapprovedRestaurants();

            Assert.AreEqual("Approved", _moderatorPanel.IdentificateApproved());
        }

        [Test]
        public void Test305_DisapproveRestoran() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=1047059404
        {
            _moderatorPanel.DisapproveRestoran();

            Assert.AreEqual("Disapproved", _moderatorPanel.IdentificateDisapproved());
        }

        [Test]
        public void Test306_DisapproveArchivedRestourants() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=1962435150
        {
            _moderatorPanel.DisapproveArchivedRestourants();

            Assert.AreEqual("Approved", _moderatorPanel.IdentificateApproved());
        }

        [Test]
        public void Test307_ShowAllUsers() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=267246974
        {
            _moderatorPanel.ShowAllUsers();

            Assert.AreEqual("Users", _moderatorPanel.IdentificateUsers());
        }

        [Test]
        public void Test308_ShowAllOwners() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=477615432
        {
            _moderatorPanel.ShowAllOwners();

            Assert.AreEqual("Owners", _moderatorPanel.IdentificateOwners());
        }

        [Test]
        public void Test309_LockUsers() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=439052715
        {
            _moderatorPanel.LockUser();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }

        [Test]
        public void Test310_LockOwner() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=919949778
        {
            _moderatorPanel.LockOwner();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }

        [Test]
        public void Test311_UnLockUser() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=764310539
        {
            _moderatorPanel.UnLockUser();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }
        
        [Test]
        public void Test312_UnLockOwner() // https://docs.google.com/spreadsheets/d/1e4BfKBii2ALPdf5tMx-Zj1FVh8En4FPr2TwRetb8VZU/edit#gid=1588327865
        {
            _moderatorPanel.UnLockOwner();

            Assert.AreEqual("success", _moderatorPanel.IdentificateSuccess());
        }
    }
}