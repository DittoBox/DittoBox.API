using DittoBox.API.AccountSubscription.Application.Services;
using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DittoBox.Tests.AccountSubscription.Application.Services
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

        [Test]
        public async Task GetAccount_ShouldReturnAccount()
        {
            // Arrange
            var accountId = 1;
            var expectedAccount = new Account
            {
                Id = accountId,
                RepresentativeId = 1,
                BusinessName = "Test Business",
                BusinessId = "12345"
            };
            _accountRepositoryMock.Setup(repo => repo.GetById(accountId)).ReturnsAsync(expectedAccount);

            // Act
            var account = await _accountService.GetAccount(accountId);

            // Assert
            Assert.AreEqual(expectedAccount, account);
        }

        [Test]
        public async Task UpdateAccountRepresentative_ShouldUpdateRepresentativeId()
        {
            // Arrange
            var accountId = 1;
            var newRepresentativeId = 2;
            var account = new Account
            {
                Id = accountId,
                RepresentativeId = 1,
                BusinessName = "Test Business",
                BusinessId = "12345"
            };
            _accountRepositoryMock.Setup(repo => repo.GetById(accountId)).ReturnsAsync(account);

            // Act
            await _accountService.UpdateAccountRepresentative(accountId, newRepresentativeId);

            // Assert
            _accountRepositoryMock.Verify(repo => repo.Update(account), Times.Once);
            Assert.AreEqual(newRepresentativeId, account.RepresentativeId);
        }

        [Test]
        public async Task UpdateAccountBusinessInformation_ShouldUpdateBusinessInformation()
        {
            // Arrange
            var accountId = 1;
            var newBusinessName = "New Business Name";
            var newBusinessId = "67890";
            var account = new Account
            {
                Id = accountId,
                RepresentativeId = 1,
                BusinessName = "Test Business",
                BusinessId = "12345"
            };
            _accountRepositoryMock.Setup(repo => repo.GetById(accountId)).ReturnsAsync(account);

            // Act
            await _accountService.UpdateAccountBusinessInformation(accountId, newBusinessName, newBusinessId);

            // Assert
            _accountRepositoryMock.Verify(repo => repo.Update(account), Times.Once);
            Assert.AreEqual(newBusinessName, account.BusinessName);
            Assert.AreEqual(newBusinessId, account.BusinessId);
        }
    }
}