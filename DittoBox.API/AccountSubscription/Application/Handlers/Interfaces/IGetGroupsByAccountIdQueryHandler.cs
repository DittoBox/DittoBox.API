using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.GroupManagement.Domain.Models.Resources;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IGetGroupsByAccountIdQueryHandler
    {
        Task<IEnumerable<GroupResource>> Handle(GetGroupsByAccountIdQuery query);
    }
}