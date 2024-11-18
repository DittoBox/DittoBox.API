using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.GroupManagement.Domain.Models.Queries;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Interfaces
{
    public class GetContainersByGroupIdQueryHandler (
        IContainerService containerService
    ) : IGetContainersByGroupIdQueryHandler
    {
        public async Task<IEnumerable<ContainerResource>> Handle(GetContainersByGroupIdQuery query)
        {
            var containers = await containerService.GetContainersByGroupId(query.GroupId);
            return containers.Select(ContainerResource.FromContainer);
        }
    }
    
}