using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class UpgradeSubscriptionCommandHandler : IUpgradeSubscriptionCommandHandler
    {
        public Task Handle(UpgradeSubscriptionCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
