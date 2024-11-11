using System.ComponentModel;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.GroupManagement.Domain.Models.Queries;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Interfaces
{
    public interface IGetContainersByGroupIdQueryHandler
    {
        public Task<IEnumerable<ContainerResource>> Handle (GetContainersByGroupIdQuery query);
    }
}