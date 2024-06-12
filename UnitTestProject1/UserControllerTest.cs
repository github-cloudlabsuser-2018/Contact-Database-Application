using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
                Id = 2,
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
                Id = 3,
                Name = "John",
                Email = "john@example.com"                
            };

            CRUD_application_2.Controllers.UserController.userlist.Add(user);

            // Act
            var result = controller.Edit(3, user) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            // Verify that the user was updated in the userlist using the name and email properties
            var editedUser = CRUD_application_2.Controllers.UserController.userlist.FirstOrDefault(u => u.Id == 3);
            Assert.AreEqual("John", editedUser.Name);
            Assert.AreEqual("john@example.com", editedUser.Email);
        }

        [TestMethod]
        public void Edit_ReturnsViewWithModelError()
        {
            // Arrange
            var controller = new CRUD_application_2.Controllers.UserController();
            var user = new CRUD_application_2.Models.User
            {
                Id = 4,
                Name = "John",
                Email = "invalidemail",
            };
            controller.ModelState.AddModelError("Email", "Invalid email format");
            CRUD_application_2.Controllers.UserController.userlist.Add(user);

            // Act
            var result = controller.Edit(4, user) as System.Web.Mvc.ViewResult;

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
                Id = 5,
                Name = "John",
                Email = "DeleteConfirmed_RedirectsToIndex@example.com",
            });

            // Act
            var result = controller.Delete(5, null) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            // Verify that there is no user with the provided email in the userlist
            Assert.AreEqual(false, CRUD_application_2.Controllers.UserController.userlist.Select(user => user.Id)?.Contains(5));
        }

        [TestMethod]
        public void Search_ReturnsCorrectUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 6, Name = "John Doe", Email = "john@example.com" },
                new User { Id = 7, Name = "Jane Doe", Email = "jane@example.com" },
                new User { Id = 8, Name = "Bob Smith", Email = "bob@example.com" }
            };
            UserController.userlist = users;
            var controller = new UserController();

            // Act
            var result = controller.Search("Doe") as ViewResult;

            // Assert
            var model = result.Model as List<User>;
            Assert.AreEqual(2, model.Count);
            Assert.IsTrue(model.Exists(u => u.Name == "John Doe"));
            Assert.IsTrue(model.Exists(u => u.Name == "Jane Doe"));
        }
    }
}
