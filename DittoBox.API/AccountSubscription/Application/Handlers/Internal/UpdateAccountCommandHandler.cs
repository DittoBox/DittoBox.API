using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class UpdateAccountCommandHandler : IUpdateAccountCommandHandler
    {
        public Task Handle(UpdateAccountCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
