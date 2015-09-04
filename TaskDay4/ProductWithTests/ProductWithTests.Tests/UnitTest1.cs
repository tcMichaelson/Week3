using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductWithTests.Models;
using System;
using System.Linq;

namespace ProductWithTests.Tests {
    [TestClass]
    public class ProductTests {
        [TestMethod]
        public void TestProductNameRequired() {
            var product = new Product {
                Name = "",
                Price = 3.33m
            };

            var results = TestHelper.Validate(product);

            Assert.IsTrue(results.Any(p => p.ErrorMessage == "Name is required."));

        }
        
        [TestMethod]
        public void TestPriceNot17() {
            var product = new Product {
                Name = "I'M SEVENTEEN",
                Price = 17.00m
            };

            var results = TestHelper.Validate(product);

            Assert.IsTrue(results.Any(p => p.ErrorMessage == "Price cannot be $17.00."));

        }
    }
}
