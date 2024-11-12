using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public class GetContainersByAccountIdQueryHandler(
        IContainerService containerService
    ) : IGetContainersByAccountIdQueryHandler
    {
        public async Task<IEnumerable<ContainerResource>> Handle(GetContainersByAccountIdQuery query)
        {
            var result = await containerService.GetContainersByAccountId(query.AccountId);
            return result.Select(ContainerResource.FromContainer);

        }
    }
}