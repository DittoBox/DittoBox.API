using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Infrastructure.Repositories;
using DittoBox.API.Shared.Infrastructure;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class ContainerRepository : BaseRepository<Container>, IContainerRepository
    {
        public ContainerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
