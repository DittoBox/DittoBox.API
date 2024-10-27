using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure.Repositories;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
    }
}
