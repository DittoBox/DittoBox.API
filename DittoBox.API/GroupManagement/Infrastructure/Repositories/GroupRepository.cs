using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.GroupManagement.Infrastructure.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
    }
}
