using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class UpdateContainerMetricsCommandHandler(
        IContainerService containerService,
        IUnitOfWork unitOfWork
        ) : IUpdateContainerMetricsCommandHandler
    {
        public async Task Handle(int containerId, UpdateContainerMetricsCommand command)
        {
            var container = await containerService.GetContainerById(containerId);
            if (container != null) 
            {
                container.UpdateMetrics(command.Temperature, command.Humidity);
                await containerService.UpdateContainer(container);
                await unitOfWork.CompleteAsync();
            }
        }
    }
}
