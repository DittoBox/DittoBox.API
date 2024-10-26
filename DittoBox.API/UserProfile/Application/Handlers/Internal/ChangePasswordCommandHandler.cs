using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class ChangePasswordCommandHandler : IChangePasswordCommandHandler
    {
        public Task Handle(ChangePasswordCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
