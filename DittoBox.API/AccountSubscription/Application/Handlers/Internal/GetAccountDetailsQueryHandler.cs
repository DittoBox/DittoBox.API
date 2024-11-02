using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class GetAccountDetailsQueryHandler : IGetAccountDetailsQueryHandler
    {
        public Task<AccountResource> Handle(GetAccountDetailsQuery query)
        {
            return Task.FromResult(new AccountResource(1, "Sample Business", 1, 1, 1));
        }
    }
}
