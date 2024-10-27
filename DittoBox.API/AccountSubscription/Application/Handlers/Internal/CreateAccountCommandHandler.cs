using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Resources;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class CreateAccountCommandHandler : ICreateAccountCommandHandler
    {
        public Task<AccountResource> Handle(CreateAccountCommand command)
        {
            return Task.FromResult(new AccountResource(1, "Sample Business", 1, 1, 1));
        }
    }
}
