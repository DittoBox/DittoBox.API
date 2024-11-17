﻿using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Interface
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
                AccountId = command.AccountId,
                GroupId = command.GroupId,
                ContainerId = command.ContainerId
            };
            await notificationRepository.Add(notification);
            await unitOfWork.CompleteAsync();
            return Ok(NotificationResource.FromNotification(notification));
        }

        [HttpGet]
        [Route("account/{accountId:int}")]
        public async Task<ActionResult<ICollection<NotificationResource>>> GetAllNotificationsByAccount([FromRoute]int accountId)
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
	
		[HttpGet]
		[Route("container/{containerId:int}/latest")]
		public async Task<ActionResult<NotificationResource?>> GetLatestNotificationByContainer([FromRoute] int containerId)
		{
			var notification = await notificationRepository.GetLatestNotificationByContainer(containerId);
			if (notification == null)
			{
				return NotFound();
			}

			return Ok(NotificationResource.FromNotification(notification));
		}

		[HttpGet]
		[Route("group/{groupId:int}/latest")]
		public async Task<ActionResult<NotificationResource?>> GetLatestNotificationByGroup([FromRoute] int groupId)
		{
			var notification = await notificationRepository.GetLatestNotificationByGroup(groupId);
			if (notification == null)
			{
				return NotFound();
			}

			return Ok(NotificationResource.FromNotification(notification));
		}

		[HttpGet]
		[Route("account/{accountId:int}/latest")]
		public async Task<ActionResult<NotificationResource?>> GetLatestNotificationByAccount([FromRoute] int accountId)
		{
			var notification = await notificationRepository.GetLatestNotificationByAccount(accountId);
			if (notification == null)
			{
				return NotFound();
			}

			return Ok(NotificationResource.FromNotification(notification));
		}

		[HttpGet]
		[Route("container/{containerId:int}/amount")]
		public async Task<ActionResult<int>> GetAmountOfNotificationsByContainer([FromRoute] int containerId)
		{
			var notifications = await notificationRepository.GetAmountOfNotificationsByContainer(containerId);
			return Ok(notifications);
		}

		[HttpGet]
		[Route("group/{groupId:int}/amount")]
		public async Task<ActionResult<int>> GetAmountOfNotificationsByGroup([FromRoute] int groupId)
		{
			var notifications = await notificationRepository.GetAmountOfNotificationsByGroup(groupId);
			return Ok(notifications);
		}

		[HttpGet]
		[Route("account/{accountId:int}/amount")]
		public async Task<ActionResult<int>> GetAmountOfNotificationsByAccount([FromRoute] int accountId)
		{
			var notifications = await notificationRepository.GetAmountOfNotificationsByAccount(accountId);
			return Ok(notifications);
		}
	}
}
