using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Services
{
	public class SubscriptionService : ISubscriptionService
	{
		public Task<Subscription> CreateSubscription(int userId, string subscriptionName, string subscriptionDescription)
		{
			throw new NotImplementedException();
		}

		public Task DeleteSubscription(int subscriptionId)
		{
			throw new NotImplementedException();
		}

		public Task<Subscription?> GetSubscription(int subscriptionId)
		{
			throw new NotImplementedException();
		}
	}
}
