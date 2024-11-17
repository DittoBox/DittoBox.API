﻿using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Domain.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        public Task<ICollection<Notification>> GetAllNotificationsByAccount(int accountId);

        public Task<ICollection<Notification>> GetAllNotificationsByGroup(int groupId);

        public Task<ICollection<Notification>> GetAllNotificationsByContainer(int containerId);

		public Task<int> GetAmountOfNotificationsByContainer(int containerId);

		public Task<Notification?> GetLatestNotificationByContainer(int containerId);

		public Task<int> GetAmountOfNotificationsByGroup(int groupId);

		public Task<Notification?> GetLatestNotificationByGroup(int groupId);

		public Task<int> GetAmountOfNotificationsByAccount(int accountId);

		public Task<Notification?> GetLatestNotificationByAccount(int accountId);

		
    }
}
