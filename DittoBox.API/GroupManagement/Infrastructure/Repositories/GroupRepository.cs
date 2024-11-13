using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.GroupManagement.Infrastructure.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> GetContainerCountByGroupId(int groupId)
        {
            return await _context.Set<Group>()
                .Where(g => g.Id == groupId)
                .Select(g => g.Containers.Count)
                .ToListAsync();
        }
        public async Task<IEnumerable<int>> GetProfileCountByGroupId(int groupId)
        {
            return await _context.Set<Group>()
                .Where(g => g.Id == groupId)
                .Select(g => g.Profiles.Count)
                .ToListAsync();
        }
    }
}