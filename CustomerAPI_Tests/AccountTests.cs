using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI_Tests
{
    [TestFixture]
    public class AccountTests
    {
        Mock<IAccountService> _accountServiceMock;
        List<Account> accounts;

        [SetUp]
        public void Setup()
        {
            accounts = new List<Account>()
            {
                new Account { ID = 1, Balance = 21, Transactions = new List<Transaction>(), CustomerID = 1},
                new Account { ID = 2, Balance = 2.31M, Transactions = new List<Transaction>(), CustomerID = 1},
                new Account { ID = 3, Balance = 21.1M, Transactions = new List<Transaction>(), CustomerID = 1},
                new Account { ID = 4, Balance = 0, Transactions = new List<Transaction>(), CustomerID = 1}
            };

            _accountServiceMock = new Mock<IAccountService>();
            _accountServiceMock.Setup(a => a.GetAccountsForCustomerAsync(1)).ReturnsAsync(accounts);
        }

       
        [Test]
        public void GetAccountsForCustomerAsync_ExistingIdPassed_ReturnsCorrectDataType()
        {
            // Arrange
            int validID = 1;

            //Act
            List<Account> validAccounts = _accountServiceMock.Object.GetAccountsForCustomerAsync(validID).Result.ToList();

            //Assert
            Assert.IsInstanceOf(typeof(List<Account>), validAccounts);
        }

        [Test]
        public void GetAccountsForCustomerAsync_ExistingIdPassed_ReturnsCorrectData()
        {
            // Arrange
            int validID = 1;

            //Act
            List<Account> validAccounts = _accountServiceMock.Object.GetAccountsForCustomerAsync(validID).Result.ToList(); ;

            //Assert
            Assert.AreEqual(validAccounts, accounts);
        }
    }
}
