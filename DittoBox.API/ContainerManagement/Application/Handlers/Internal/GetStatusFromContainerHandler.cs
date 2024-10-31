using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class GetStatusFromContainerHandler(
        IContainerService containerService
        ) : IGetStatusFromContainerHandler
    {
        public async Task<ContainerStatusResource?> Handle(GetContainerByIdQuery query)
        {
            var result = await containerService.GetContainerById(query.containerId);
            return result == null ? null : ContainerStatusResource.FromContainer(result);
        }
    }
}
