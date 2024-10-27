using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class UpdateBusinessInformationCommandHandler : IUpdateBusinessInformationCommandHandler
    {
        public Task Handle(UpdateBusinessInformationCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
