using DittoBox.API.GroupManagement.Domain.Models.ValueObject;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.GroupManagement.Infrastructure.Repositories
{
    public class ContainerLinkingRepository : BaseRepository<ContainerLinking>, IContainerLinkingRepository
    {
    }
}
