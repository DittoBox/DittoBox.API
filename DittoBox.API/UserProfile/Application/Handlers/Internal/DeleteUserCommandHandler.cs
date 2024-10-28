using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Domain.Services.Application;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class DeleteUserCommandHandler(
        IUserService userService,
        IUnitOfWork unitOfWork
        ) : IDeleteUserCommandHandler
    {
        public async Task Handle(DeleteUserCommand command)
        {
            await userService.DeleteUser(command.UserId);
            await unitOfWork.CompleteAsync();
        }
    }
}
