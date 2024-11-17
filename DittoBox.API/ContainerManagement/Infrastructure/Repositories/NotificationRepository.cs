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

		public async Task<int> GetAmountOfNotificationsByContainer(int containerId)
		{
			return await context.Notifications
				.Where(n => n.ContainerId == containerId)
				.CountAsync();
		}

		public Task<Notification?> GetLatestNotificationByContainer(int containerId)
		{
			return context.Notifications
				.Where(n => n.ContainerId == containerId)
				.OrderByDescending(n => n.IssuedAt)
				.FirstOrDefaultAsync();
		}

		public Task<int> GetAmountOfNotificationsByGroup(int groupId)
		{
			return context.Notifications
				.Where(n => n.GroupId == groupId)
				.CountAsync();
		}

		public Task<Notification?> GetLatestNotificationByGroup(int groupId)
		{
			return context.Notifications
				.Where(n => n.GroupId == groupId)
				.OrderByDescending(n => n.IssuedAt)
				.FirstOrDefaultAsync();
		}

		public Task<int> GetAmountOfNotificationsByAccount(int accountId)
		{
			return context.Notifications
				.Where(n => n.AccountId == accountId)
				.CountAsync();
		}

		public Task<Notification?> GetLatestNotificationByAccount(int accountId)
		{
			return context.Notifications
				.Where(n => n.AccountId == accountId)
				.OrderByDescending(n => n.IssuedAt)
				.FirstOrDefaultAsync();
		}
	}
}
