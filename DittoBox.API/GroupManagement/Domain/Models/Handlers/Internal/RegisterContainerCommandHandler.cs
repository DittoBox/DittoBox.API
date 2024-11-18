using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Handlers.Interfaces;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal
{
    public class RegisterContainerCommandHandler(
		IContainerService containerService,
		IUnitOfWork unitOfWork,
		ILogger<RegisterContainerCommandHandler> logger
	) : IRegisterContainerCommandHandler
	{
		public async Task<ContainerRegistrationResource> Handle(RegisterContainerCommand command)
		{
			var container = await containerService.GetContainerByUuid(command.Uiid);
			if (container != null)
			{
                logger.LogWarning("Container with serial number {serialNumber} already exists", command.Uiid);
                return new ContainerRegistrationResource(container.Id, container.Uiid);
            }
			container = await containerService.RegisterContainer(command.Uiid);
			await unitOfWork.CompleteAsync();
			return new ContainerRegistrationResource(container.Id, container.Uiid);
		}
	}
}