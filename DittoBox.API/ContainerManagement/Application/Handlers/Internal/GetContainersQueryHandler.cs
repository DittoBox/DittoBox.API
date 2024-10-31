using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class GetContainersQueryHandler(
        IContainerService containerService
        ) : IGetAccountDetailsQueryHandler
    {
        public async Task<IEnumerable<ContainerResource>> Handle(GetContainersByGroupIdQuery query)
        {
            var result = await containerService.GetAllByGroupId(query.GroupId);

            if (result == null || !result.Any())
                return Enumerable.Empty<ContainerResource>();

            return result.Select(ContainerResource.FromContainer);
        }
    }
}
