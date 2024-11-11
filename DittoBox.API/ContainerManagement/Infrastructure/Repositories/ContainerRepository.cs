using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Infrastructure.Repositories;
using DittoBox.API.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class ContainerRepository : BaseRepository<Container>, IContainerRepository
    {
        private readonly ApplicationDbContext _context;

        public ContainerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Container>> GetContainersByGroupId(int groupId)
        {
            return await _context.Containers.Where(c => c.GroupId == groupId).ToListAsync();
        }
    }
}