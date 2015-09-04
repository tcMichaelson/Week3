using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Identity.Models;
using System.Collections.Generic;
using System.Linq;
using Identity.Controllers;
using Moq;

namespace UnitTest1 {
    [TestClass]
    public class HomeControllerTests {
        [TestMethod]
        public void TestIndexMethod() {

            var users = new List<ApplicationUser> {
                new ApplicationUser {
                    FirstName = "Tom",
                    LastName = "Michaelson",
                    UserName = "tmichael"
                },
                new ApplicationUser {
                    FirstName = "Frank",
                    LastName = "Stromdahl",
                    UserName = "freestada"
                },
                new ApplicationUser {
                    FirstName = "Ed",
                    LastName = "Cantata",
                    UserName = "ecantada"
                }

            };

            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(mock => mock.Query<ApplicationUser>()).Returns(users.AsQueryable());
            var homeController = new HomeController(mockRepo.Object);

            var results = homeController.Index() as ViewResult;
            var model = results.Model as IList<ApplicationUser>;

            Assert.AreEqual("Ed", model.First().FirstName);
        }
    }
}
