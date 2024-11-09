using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.ContainerManagement.Application.Services;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.UserProfile.Application.Services;
using DittoBox.API.UserProfile.Domain.Repositories;
using DittoBox.API.UserProfile.Domain.Services.Application;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal
{
    public class RegisterContainerCommandHandler(
        IContainerService containerService,
        IProfileService profileService,
        IUnitOfWork unitOfWork
    ) : IRegisterContainerCommandHandler
    {
        public async Task Handle(RegisterContainerCommand command)
        {
            var container = await containerService.GetContainerById(command.ContainerId);
            var profile = await profileService.GetProfile(command.AccountId);
            if (container == null)
            {
                throw new Exception("Container not found");
            }
            if (profile == null)
            {
                throw new Exception("Profile not found");
            }
            profile.GroupId = command.GroupId;
            await unitOfWork.CompleteAsync();
        }
    }
}