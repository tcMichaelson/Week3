using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourLayer.Domain.Models;
using FourLayer.Services.Models;
using FourLayer.Infrastructure.Models;

namespace FourLayer.Services.Tests {
    [TestClass]
    public class ServicesTests {
        [TestMethod]
        public void TransferMoneyMethodTest() {
            //Arrange
            Account accountFrom = new Account {
                Name = "Tom",
                AccountNumber = "1234567890",
                Balance = 35.00m,
                AccountType = "Checking"
            };

            Account accountTo = new Account {
                Name = "Dave",
                AccountNumber = "0987654321",
                Balance = 732.21m,
                AccountType = "Savings"
            };

            var accService = new AccountService(new Repository(new DataContext()));

            //Act
            accService.TransferMoney(accountFrom, accountTo, 20.0m);
            var result = accountFrom.Balance;
            //Assert

            Assert.AreEqual(result, 15m);
        }
    }
}
