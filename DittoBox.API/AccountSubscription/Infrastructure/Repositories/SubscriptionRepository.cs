using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Infrastructure.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
    }
}
