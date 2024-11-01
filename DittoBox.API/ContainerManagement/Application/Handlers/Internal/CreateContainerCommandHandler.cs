using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class CreateContainerCommandHandler(
        IContainerService containerService,
        IUnitOfWork unitOfWork
        ) : ICreateContainerCommandHandler
    {
        public async Task<CreateContainerResource> Handle(CreateContainerCommand command)
        {
            var result = await containerService.CreateContainer(command.Name, command.Description, command.AccountId, command.GroupId, command.ContainerSizeId);
            await unitOfWork.CompleteAsync();
            return CreateContainerResource.FromContainer(result);
        }
    }
}
