using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class AlertRepository : BaseRepository<Alert>, IAlertRepository
    {
    }
}
