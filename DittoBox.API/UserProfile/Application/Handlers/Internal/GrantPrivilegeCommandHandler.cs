using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class GrantPrivilegeCommandHandler : IGrantPrivilegeCommandHandler
    {
        public Task Handle(GrantPrivilegeCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
