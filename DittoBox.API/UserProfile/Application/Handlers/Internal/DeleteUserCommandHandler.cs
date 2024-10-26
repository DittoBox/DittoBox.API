using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class DeleteUserCommandHandler : IDeleteUserCommandHandler
    {
        public Task Handle(DeleteUserCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
