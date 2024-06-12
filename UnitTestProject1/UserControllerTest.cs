using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Index_ReturnsView()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Index() as System.Web.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_ReturnsView()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Details(1) as System.Web.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_ReturnsHttpNotFoundResult()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Details(100) as System.Web.Mvc.HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_ReturnsView()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Create() as System.Web.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_RedirectsToIndex()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();
            var user = new CRUD_application_2.Models.User
            {
                Id = 1,
                Name = "John",
                Email = "john@example.com",
            };
            // Act
            var result = controller.Create(user) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            // Verify that the user was added to the userlist using the name and email properties
            Assert.AreEqual(1, CRUD_application_2.Controllers.UserController.userlist.Count);
            Assert.AreEqual("John", CRUD_application_2.Controllers.UserController.userlist[0].Name);
            Assert.AreEqual("john@example.com", CRUD_application_2.Controllers.UserController.userlist[0].Email);
        }

        [TestMethod]
        public void Create_ReturnsViewWithModelError()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();
            var user = new CRUD_application_2.Models.User
            {
                Id = 1,
                Name = "John",
                Email = "invalidemail",
            };
            controller.ModelState.AddModelError("Email", "Invalid email format");

            // Act
            var result = controller.Create(user) as System.Web.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void Edit_ReturnsView()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Edit(1) as System.Web.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_ReturnsHttpNotFoundResult()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Edit(100) as System.Web.Mvc.HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_RedirectsToIndex()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();
            var user = new CRUD_application_2.Models.User
            {
                Id = 1,
                Name = "John",
                Email = "john@example.com"
            };

            // Act
            var result = controller.Edit(1, user) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            // Verify that the user was updated in the userlist using the name and email properties
            Assert.AreEqual(1, CRUD_application_2.Controllers.UserController.userlist.Count);
            Assert.AreEqual("John", CRUD_application_2.Controllers.UserController.userlist[0].Name);
            Assert.AreEqual("john@example.com", CRUD_application_2.Controllers.UserController.userlist[0].Email);
        }

        [TestMethod]
        public void Edit_ReturnsViewWithModelError()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();
            var user = new CRUD_application_2.Models.User
            {
                Id = 1,
                Name = "John",
                Email = "invalidemail",
            };
            controller.ModelState.AddModelError("Email", "Invalid email format");

            // Act
            var result = controller.Edit(1, user) as System.Web.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void Delete_ReturnsView()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Delete(1) as System.Web.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_ReturnsHttpNotFoundResult()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();

            // Act
            var result = controller.Delete(100) as System.Web.Mvc.HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void DeleteConfirmed_RedirectsToIndex()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();
            CRUD_application_2.Controllers.UserController.userlist.Add(new CRUD_application_2.Models.User
            {
                Id = 1,
                Name = "John",
                Email = "john@example.com",
            });

            // Act
            var result = controller.Delete(1) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            // Verify that the user was removed from the userlist
            Assert.AreEqual(0, CRUD_application_2.Controllers.UserController.userlist.Count);
        }
    }
}
