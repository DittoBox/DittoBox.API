using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
    }
}
