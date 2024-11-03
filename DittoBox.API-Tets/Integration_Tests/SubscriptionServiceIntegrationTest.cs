using NUnit.Framework;
using Moq;
using DittoBox.API.AccountSubscription.Application.Services;
using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using System.Threading.Tasks;

namespace DittoBox.Tests.Integration
{
    [TestFixture]
    public class SubscriptionServiceTests
    {
        private Mock<ISubscriptionRepository> _subscriptionRepositoryMock;
        private SubscriptionService _subscriptionService;

        [SetUp]
        public void Setup()
        {
            _subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            _subscriptionService = new SubscriptionService(_subscriptionRepositoryMock.Object);
        }

        [Test]
        public async Task CreateSubscription_ShouldAddSubscription()
        {
            // Arrange
            var accountId = 1;

            // Act
            var subscription = await _subscriptionService.CreateSubscription(accountId);

            // Assert
            _subscriptionRepositoryMock.Verify(repo => repo.Add(It.IsAny<Subscription>()), Times.Once);
            Assert.AreEqual(accountId, subscription.AccountId);
            Assert.AreEqual(0, subscription.TierId);
            Assert.AreEqual(1, subscription.SubscriptionStatusId);
        }
    }
}