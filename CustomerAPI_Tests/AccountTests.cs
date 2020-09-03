using AutoMapper;
using CustomerAPI.Controllers;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.Mapping;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI.Resources.Communication;
using CustomerAPI.Resources.Classes;
using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Resources.ViewModels;

namespace CustomerAPI_Tests
{
    [TestFixture]
    public class AccountTests
    {
        AccountController _accountController;
        Mock<IAccountService> _accountServiceMock;
        AccountViewModel accountToTestSave;
        SaveAccountResource saveAccountResource;

        [SetUp]
        public void Setup()
        {

            saveAccountResource = new SaveAccountResource()
            {
                CustomerID = 1,
                InitialCredit = 21
            };

            accountToTestSave = new AccountViewModel()
            {
                ID = 0,
                Balance = 21
            };

            _accountServiceMock = new Mock<IAccountService>();
            _accountServiceMock.Setup(a => a.PostAccountAsync(1,21)).ReturnsAsync(new SaveAccountResponse(accountToTestSave));
                        
            _accountController = new AccountController(_accountServiceMock.Object);
        }

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
            var item = (AccountViewModel) itemAsObject; 

            // Assert
            Assert.IsInstanceOf(typeof(AccountViewModel), itemAsObject);
            Assert.AreEqual(accountToTestSave.Balance, item.Balance);
        }

    }
}
