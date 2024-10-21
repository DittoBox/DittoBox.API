using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class ContainerRepository : BaseRepository<Container>, IContainerRepository
    {
    }
}
