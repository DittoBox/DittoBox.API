using DittoBox.API.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
    public record NotificationResource
    {
        public int Id { get; set; }
        public string AlertType { get; set; }  = string.Empty;
        public DateTime IssuedAt { get; set; }
        public int AccountId { get; set; }
        public int GroupId { get; set; }
        public int ContainerId { get; set; }

        NotificationResource()
        {

        }

        public static NotificationResource FromNotification(Notification notification) =>
            new NotificationResource
            {
                Id = notification.Id,
                AlertType = notification.AlertType.ToString(),
                IssuedAt = notification.IssuedAt,
                AccountId = notification.AccountId,
                GroupId = notification.GroupId,
                ContainerId = notification.ContainerId
            };
    }
}
