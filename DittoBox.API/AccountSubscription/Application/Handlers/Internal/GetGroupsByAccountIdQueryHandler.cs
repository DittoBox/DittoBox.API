using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using DittoBox.API.GroupManagement.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class GetGroupsByAccountIdQueryHandler (
        IGroupService groupService
    ): IGetGroupsByAccountIdQueryHandler
    {
        public async Task<IEnumerable<GroupResource>> Handle(GetGroupsByAccountIdQuery query)
        {
            var result = await groupService.GetGroupsByAccountId(query.AccountId);
            return result.Select(GroupResource.FromGroup);
        }
    }
}