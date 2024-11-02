using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Services
{
	public class SubscriptionService(
		ISubscriptionRepository subscriptionRepository
	) : ISubscriptionService
	{
		public async Task<Subscription> CreateSubscription(int accountId, string subscriptionName, string subscriptionDescription)
		{
			var subscription = new Subscription(){
				AccountId = accountId,
				TierId = 0,
				PaymentDate = DateOnly.FromDateTime(DateTime.Now),
				SubscriptionStatusId = 1,
				LastPaidPeriod = DateOnly.FromDateTime(DateTime.Now)
			};
			await subscriptionRepository.Add(subscription);
			return subscription;
		}

		public Task DeleteSubscription(int subscriptionId)
		{
			throw new NotImplementedException();
		}

		public async Task<Subscription?> GetSubscription(int subscriptionId)
		{
			return await subscriptionRepository.GetById(subscriptionId);
		}

		public Task<Subscription?> GetSubscriptionByAccountId(int accountId)
		{
			throw new NotImplementedException();
		}

		public Task UpdateSubscriptionTier(int subscriptionTierId)
		{
			throw new NotImplementedException();
		}
	}
}
