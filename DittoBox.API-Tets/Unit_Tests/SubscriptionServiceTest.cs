using DittoBox.API.AccountSubscription.Application.Services;
using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace DittoBox.Tests.AccountSubscription.Application.Services
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

        [Test]
        public async Task GetSubscription_ShouldReturnSubscription()
        {
            // Arrange
            var subscriptionId = 1;
            var expectedSubscription = new Subscription
            {
                Id = subscriptionId,
                AccountId = 1,
                TierId = 0,
                PaymentDate = DateOnly.FromDateTime(DateTime.Now),
                SubscriptionStatusId = 1,
                LastPaidPeriod = DateOnly.FromDateTime(DateTime.Now)
            };
            _subscriptionRepositoryMock.Setup(repo => repo.GetById(subscriptionId)).ReturnsAsync(expectedSubscription);

            // Act
            var subscription = await _subscriptionService.GetSubscription(subscriptionId);

            // Assert
            Assert.AreEqual(expectedSubscription, subscription);
        }

        [Test]
        public async Task DeleteSubscription_ShouldRemoveSubscription()
        {
            // Arrange
            var subscriptionId = 1;
            var subscription = new Subscription
            {
                Id = subscriptionId,
                AccountId = 1,
                TierId = 0,
                PaymentDate = DateOnly.FromDateTime(DateTime.Now),
                SubscriptionStatusId = 1,
                LastPaidPeriod = DateOnly.FromDateTime(DateTime.Now)
            };
            _subscriptionRepositoryMock.Setup(repo => repo.GetById(subscriptionId)).ReturnsAsync(subscription);

            // Act
            await _subscriptionService.DeleteSubscription(subscriptionId);

            // Assert
            _subscriptionRepositoryMock.Verify(repo => repo.Delete(subscription), Times.Once);
        }

        [Test]
        public async Task UpdateSubscriptionTier_ShouldUpdateTierId()
        {
            // Arrange
            var subscriptionId = 1;
            var newTierId = 2;
            var subscription = new Subscription
            {
                Id = subscriptionId,
                AccountId = 1,
                TierId = 0,
                PaymentDate = DateOnly.FromDateTime(DateTime.Now),
                SubscriptionStatusId = 1,
                LastPaidPeriod = DateOnly.FromDateTime(DateTime.Now)
            };
            _subscriptionRepositoryMock.Setup(repo => repo.GetById(subscriptionId)).ReturnsAsync(subscription);

            // Act
            await _subscriptionService.UpdateSubscriptionTier(subscriptionId, newTierId);

            // Assert
            _subscriptionRepositoryMock.Verify(repo => repo.Update(subscription), Times.Once);
            Assert.AreEqual(newTierId, subscription.TierId);
        }
    }
}