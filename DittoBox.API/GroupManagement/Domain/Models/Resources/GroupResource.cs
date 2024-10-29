
using DittoBox.API.GroupManagement.Domain.Models.Entities;

namespace DittoBox.API.GroupManagement.Domain.Models.Resources
{
    public record GroupResource(
        int Id,
        string Name,
        Location Location,
        int AccountId
    );

    public static class GroupResourceExtensions
    {
        public static GroupResource ToResource(this Group group)
        {
            return new GroupResource(group.Id, group.Name, group.Location, group.AccountId);
        }
    }


}