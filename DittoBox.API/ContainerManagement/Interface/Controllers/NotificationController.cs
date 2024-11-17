using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotificationController(
        INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<NotificationResource>> CreateNotification([FromBody] CreateNotificationCommand command)
        {
            var notification = new Notification
            {
                AlertType = (AlertType)command.AlertType,
                IssuedAt = DateTime.UtcNow,
                AccountId = command.AccountId ?? 0,
                GroupId = command.GroupId ?? 0,
                ContainerId = command.ContainerId ?? 0
            };
            await notificationRepository.Add(notification);
            await unitOfWork.CompleteAsync();
            return Ok(NotificationResource.FromNotification(notification));
        }

        [HttpGet]
        [Route("account/{accountId:int}")]
        public async Task<ActionResult<ICollection<NotificationResource>>> GetAllNotificationsByAccount([FromRoute] int accountId)
        {
            var notifications = await notificationRepository.GetAllNotificationsByAccount(accountId);
            return Ok(notifications.Select(NotificationResource.FromNotification));

        }

        [HttpGet]
        [Route("group/{groupId:int}")]
        public async Task<ActionResult<ICollection<NotificationResource>>> GetAllNotificationsByGroup([FromRoute] int groupId)
        {
            var notifications = await notificationRepository.GetAllNotificationsByGroup(groupId);
            return Ok(notifications.Select(NotificationResource.FromNotification));
        }

        [HttpGet]
        [Route("container/{containerId:int}")]
        public async Task<ActionResult<ICollection<NotificationResource>>> GetAllNotificationsByContainer([FromRoute] int containerId)
        {
            var notifications = await notificationRepository.GetAllNotificationsByContainer(containerId);
            return Ok(notifications.Select(NotificationResource.FromNotification));
        }
    }
}
