using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class DeleteAccountCommandHandler : IDeleteAccountCommandHandler
    {
        public Task Handle(DeleteAccountCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
