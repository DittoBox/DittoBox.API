using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController(
        ILogger<SubscriptionController> logger,
        IGetSubscriptionDetailsQueryHandler getSubscriptionDetailsQueryHandler,
        IUpgradeSubscriptionCommandHandler upgradeSubscriptionCommandHandler,
        IDowngradeSubscriptionCommandHandler downgradeSubscriptionCommandHandler,
        ICancelSubscriptionCommandHandler cancelSubscriptionCommandHandler
        ) : ControllerBase
    {
        [HttpGet]
        [Route("{query:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResource))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionResource>> GetSubscriptionDetails([FromRoute]GetSubscriptionDetailsQuery query)
        {
            try
            {
                var response = await getSubscriptionDetailsQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting subscription details for subscription {query.SubscriptionId}", query.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("upgrade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResource))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionResource>> UpgradeSubscription([FromBody] UpgradeSubscriptionCommand command)
        {
            try
            {
                await upgradeSubscriptionCommandHandler.Handle(command);
                logger.LogInformation("Upgraded subscription {command.SubscriptionId}", command.SubscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error upgrading subscription {command.SubscriptionId}", command.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("downgrade")]
        public async Task<IActionResult> DowngradeSubscription([FromBody] DowngradeSubscriptionCommand command)
        {
            try
            {
                await downgradeSubscriptionCommandHandler.Handle(command);
                logger.LogInformation("Downgraded subscription {command.SubscriptionId}", command.SubscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error downgrading subscription {command.SubscriptionId}", command.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelSubscription([FromBody] CancelSubscriptionCommand command)
        {
            try
            {
                await cancelSubscriptionCommandHandler.Handle(command);
                logger.LogInformation("Subscription {command.SubscriptionId} cancelled", command.SubscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error cancelling subscription {command.SubscriptionId}", command.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
