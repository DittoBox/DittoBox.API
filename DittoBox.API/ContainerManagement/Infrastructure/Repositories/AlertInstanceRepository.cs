using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class AlertInstanceRepository : BaseRepository<AlertInstance>, IAlertInstanceRepository
    {
    }
}
