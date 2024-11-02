using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using DittoBox.API.AccountSubscription.Domain.Models.ValueObjects;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class GetSubscriptionDetailsQueryHandler : IGetSubscriptionDetailsQueryHandler
    {
        public Task<SubscriptionDetailsResource> Handle(GetSubscriptionDetailsQuery query)
        {
            return Task.FromResult(
                new SubscriptionDetailsResource(
                    1, "SampleStatus", DateOnly.FromDateTime(DateTime.Now), SubscriptionStatus.Active.ToString(), DateOnly.FromDateTime(DateTime.Now))
                );
        }
    }
}
