using CustomerAPI.Controllers;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI_Tests
{
    
    [TestFixture]
    public class CustomerTests
    {
        Mock<ICustomerService> _customerServiceMock;
        CustomerController _customerController;
        CustomerViewModel customer;

        [SetUp]
        public void Setup()
        {
            customer = new CustomerViewModel() { ID = 1, Name = "Snow", Surname = "White", Accounts = new List<AccountViewModel>() };
            _customerServiceMock = new Mock<ICustomerService>();
            _customerServiceMock.Setup(c => c.GetCustomerAsync(1)).ReturnsAsync(customer);

            _customerController = new CustomerController(_customerServiceMock.Object);

        }

        [Test]
        public async Task GetCustomerAsync_UnkownIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            int notValidID = -1;

            //Act
            var notFoundCustomer = await _customerController.GetCustomerAsync(notValidID);

            // Assert
            Assert.IsInstanceOf(typeof(NotFoundResult), notFoundCustomer.Result);
        }

        [Test]
        public async Task GetCustomerAsync_ExistingIdPassed_ReturnsCorrectResponse()
        {
            // Arrange
            int validID = 1;

            //Act
            var validCustomer = await _customerController.GetCustomerAsync(validID);

            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), validCustomer.Result);
        }

        [Test]
        public async Task GetCustomerAsync_ExistingIdPassed_ReturnsCorrectData()
        {
            // Arrange
            int validID = 1;

            //Act
            var validCustomer = await _customerController.GetCustomerAsync(validID);
            var item = (OkObjectResult)validCustomer.Result;
            
            //Assert
            Assert.AreEqual(customer, item.Value);
        }
    }
    
}