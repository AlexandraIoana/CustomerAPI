using AutoMapper;
using CustomerAPI.Controllers;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAPI.Resources.Extensions;
using CustomerAPI.Resources.Communication;
using CustomerAPI.Resources.Classes;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI_Tests
{
    [TestFixture]
    public class AccountTests
    {
        AccountController _accountController;
        Mock<IAccountService> _accountServiceMock;
        List<Account> accounts;
        Account accountToTestSave;
        SaveAccountResource saveAccountResource;
        Mapper _mapper;

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

            saveAccountResource = new SaveAccountResource()
            {
                CustomerID = 1,
                InitialCredit = 21
            };

            accountToTestSave = new Account()
            {
                ID = 0,
                Balance = 21,
                CustomerID = 1
            };

            _accountServiceMock = new Mock<IAccountService>();
            _accountServiceMock.Setup(a => a.GetAccountsForCustomerAsync(1)).ReturnsAsync(accounts);
            _accountServiceMock.Setup(a => a.PostAccountAsync(It.IsAny<Account>())).ReturnsAsync(new SaveAccountResponse(accountToTestSave));

            var mapperProfile = new DtoToViewModelProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
            _mapper = new Mapper(configuration);

            
            _accountController = new AccountController(_accountServiceMock.Object, _mapper);
        }


        #region GET TESTS
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
        #endregion

        #region POST TESTS

        [Test]
        public async Task PostAccountAsync_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new SaveAccountResource()
            {
                InitialCredit = 23
            };
            _accountController.ModelState.AddModelError("ClientID", "Required");

            // Act
            var badResponse = await _accountController.PostAccountAsync(nameMissingItem);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), badResponse);
        }

        [Test]
        public async Task PostAccountAsync_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Act
            var createdResponse = await _accountController.PostAccountAsync(saveAccountResource);
            
            // Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), createdResponse);
        }

        [Test]
        public async Task PostAccountAsync_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Act
            var createdResponse = (OkObjectResult) await _accountController.PostAccountAsync(saveAccountResource);
            var itemAsObject = createdResponse.Value;
            var item = (Account) itemAsObject; 

            // Assert
            Assert.IsInstanceOf(typeof(Account), itemAsObject);
            Assert.AreEqual(accountToTestSave.Balance, item.Balance);
        }

        #endregion
    }
}
