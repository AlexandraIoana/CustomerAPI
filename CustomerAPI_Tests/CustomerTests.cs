using CustomerAPI.Controllers;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
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
        Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer() { ID = 1, Name = "Snow", Surname = "White", Accounts = new List<Account>() };
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
            Customer notFoundCustomer = await _customerController.GetCustomerAsync(notValidID);

            //Assert
            Assert.IsNull(notFoundCustomer);
        }

        [Test]
        public async Task GetCustomerAsync_ExistingIdPassed_ReturnsCorrectDataType()
        {
            // Arrange
            int validID = 1;

            //Act
            Customer validCustomer = await _customerController.GetCustomerAsync(validID);

            //Assert
            Assert.IsInstanceOf(typeof(Customer), validCustomer);
        }

        [Test]
        public async Task GetCustomerAsync_ExistingIdPassed_ReturnsCorrectData()
        {
            // Arrange
            int validID = 1;

            //Act
            Customer validCustomer = await _customerController.GetCustomerAsync(validID);

            //Assert
            Assert.AreEqual(validCustomer, customer);
        }
    }
    
}