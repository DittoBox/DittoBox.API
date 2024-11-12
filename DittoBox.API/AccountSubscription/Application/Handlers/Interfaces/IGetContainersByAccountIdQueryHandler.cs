using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public interface IGetContainersByAccountIdQueryHandler
    {
        Task<IEnumerable<ContainerResource>> Handle(GetContainersByAccountIdQuery query);
    }
}