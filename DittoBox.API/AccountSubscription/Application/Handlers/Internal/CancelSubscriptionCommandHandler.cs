using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class CancelSubscriptionCommandHandler : ICancelSubscriptionCommandHandler
    {
        public Task Handle(CancelSubscriptionCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
