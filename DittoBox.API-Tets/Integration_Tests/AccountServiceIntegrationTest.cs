using NUnit.Framework;
using Moq;
using DittoBox.API.AccountSubscription.Application.Services;
using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using System.Threading.Tasks;

namespace DittoBox.Tests.Integration
{
    [TestFixture]
    public class AccountServiceTests
    {
        private Mock<IAccountRepository> _accountRepositoryMock;
        private AccountService _accountService;

        [SetUp]
        public void Setup()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _accountService = new AccountService(_accountRepositoryMock.Object);
        }

        [Test]
        public async Task CreateAccount_ShouldAddAccount()
        {
            // Arrange
            var representativeId = 1;
            var businessName = "Test Business";
            var businessId = "12345";

            // Act
            var account = await _accountService.CreateAccount(representativeId, businessName, businessId);

            // Assert
            _accountRepositoryMock.Verify(repo => repo.Add(It.IsAny<Account>()), Times.Once);
            Assert.AreEqual(representativeId, account.RepresentativeId);
            Assert.AreEqual(businessName, account.BusinessName);
            Assert.AreEqual(businessId, account.BusinessId);
        }
    }
}