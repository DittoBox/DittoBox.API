using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class DowngradeSubscriptionCommandHandler : IDowngradeSubscriptionCommandHandler
    {
        public Task Handle(DowngradeSubscriptionCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
