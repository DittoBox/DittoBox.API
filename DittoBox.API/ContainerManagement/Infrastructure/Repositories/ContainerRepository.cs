using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Infrastructure.Repositories;
using DittoBox.API.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class ContainerRepository(ApplicationDbContext context) : BaseRepository<Container>(context), IContainerRepository
    {}
}
