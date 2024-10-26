using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class RevokePrivilegeCommandHandler : IRevokePrivilegeCommandHandler
    {
        public Task Handle(RevokePrivilegeCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
