using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericApp;
using GenericApp.Controllers;
using GenericApp.BusinessLogic.IService;
using Moq;
using GenericApp.Common.ViewModels;

namespace GenericApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly Mock<IUserService> userService;
        public HomeControllerTest()
        {
            var mockuserService = new Moq.Mock<IUserService>();
            mockuserService.Setup(q => q.CheckUserForLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            mockuserService.Setup(q => q.CheckUserForRegister(It.IsAny<string>())).Returns(true);
            mockuserService.Setup(q => q.GetUsers()).Returns(new List<UserViewModel> { new UserViewModel(),new UserViewModel() });
            userService = mockuserService;
        }
        [TestMethod]
        public void Index()
        {

            // Arrange
            HomeController controller = new HomeController(userService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(userService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(userService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
