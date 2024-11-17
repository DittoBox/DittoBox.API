using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        private readonly ApplicationDbContext context;

        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<Notification>> GetAllNotificationsByAccount(int accountId)
        {
            return await context.Notifications
                .Where(n => n.AccountId == accountId)
                .OrderByDescending(n => n.IssuedAt)
                .ToListAsync();
        }

        public async Task<ICollection<Notification>> GetAllNotificationsByGroup(int groupId)
        {
            return await context.Notifications
                .Where(n => n.GroupId == groupId)
                .OrderByDescending(n => n.IssuedAt)
                .ToListAsync();
        }

        public async Task<ICollection<Notification>> GetAllNotificationsByContainer(int containerId)
        {
            return await context.Notifications
                .Where(n => n.ContainerId == containerId)
                .OrderByDescending(n => n.IssuedAt)
                .ToListAsync();
        }
    }
}
