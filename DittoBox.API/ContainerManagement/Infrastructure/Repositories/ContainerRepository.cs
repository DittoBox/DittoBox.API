using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Infrastructure.Repositories;
using DittoBox.API.Shared.Infrastructure;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class ContainerRepository : BaseRepository<Container>, IContainerRepository
    {
        private readonly ApplicationDbContext _context;
        public ContainerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Container>> GetAllByGroupId(int groupId) {
            return await _context.Set<Container>()..Where(c => c.GroupId == groupId).ToListAsync();
        }
    }
}
