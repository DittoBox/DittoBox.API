using DittoBox.API.AccountSubscription.Domain.Models.Entities;

namespace DittoBox.API.AccountSubscription.Domain.Services.Application
{
    public interface ISubscriptionService
    {
		public Task<Subscription> CreateSubscription(int accountId, string subscriptionName, string subscriptionDescription);
		public Task DeleteSubscription(int subscriptionId);
		public Task<Subscription?> GetSubscriptionByAccountId(int accountId);
		public Task UpdateSubscriptionTier(int subscriptionTierId);
    }
}
