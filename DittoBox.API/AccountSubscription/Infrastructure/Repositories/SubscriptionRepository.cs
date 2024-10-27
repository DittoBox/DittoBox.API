using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure.Repositories;

namespace DittoBox.API.AccountSubscription.Infrastructure.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
    }
}
