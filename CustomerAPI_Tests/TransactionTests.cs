using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerAPI_Tests
{
    [TestFixture]
    public class TransactionTests
    {
        Mock<ITransactionService> _transactionServiceMock;
        List<Transaction> transactions;

        [SetUp]
        public void Setup()
        {
            transactions = new List<Transaction>()
            {
                new Transaction { ID = 1, Amount = 21, AccountID = 1},
                new Transaction { ID = 2, Amount = 2.34M, AccountID = 1},
                new Transaction { ID = 3, Amount = 25.4M, AccountID = 1},
                new Transaction { ID = 4, Amount = 121, AccountID = 1}
            };

            _transactionServiceMock = new Mock<ITransactionService>();
            _transactionServiceMock.Setup(a => a.GetTransactionsForAccountAsync(1)).ReturnsAsync(transactions);
        }


        [Test]
        public void GetTransactionsForAccountAsync_ExistingIdPassed_ReturnsCorrectDataType()
        {
            // Arrange
            int validID = 1;

            //Act
            List<Transaction> validTransactions = _transactionServiceMock.Object.GetTransactionsForAccountAsync(validID).Result.ToList();

            //Assert
            Assert.IsInstanceOf(typeof(List<Transaction>), validTransactions);
        }

        [Test]
        public void GetTransactionsForAccountAsync_ExistingIdPassed_ReturnsCorrectData()
        {
            // Arrange
            int validID = 1;

            //Act
            List<Transaction> validTransactions = _transactionServiceMock.Object.GetTransactionsForAccountAsync(validID).Result.ToList(); ;

            //Assert
            Assert.AreEqual(validTransactions, transactions);
        }
    }
}
