using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Interface.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
    /// <summary>
    /// Controller for managing subscription-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        /// <summary>
        /// Retrieves details of a specific subscription.
        /// </summary>
        /// <param name="query">The query containing the subscription ID.</param>
        /// <returns>A <see cref="SubscriptionResponse"/> with the subscription details.</returns>
        [HttpGet]
        [Route("{subscriptionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubscriptionResponse> GetSubscriptionDetails([FromRoute]GetSubscriptionDetailsQuery query)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Upgrades an existing subscription to a higher tier.
        /// </summary>
        /// <param name="command">The command containing upgrade details.</param>
        /// <returns>A <see cref="SubscriptionResponse"/> representing the upgraded subscription.</returns>
        [HttpPost]
        [Route("upgrade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubscriptionResponse> UpgradeSubscription([FromBody] UpgradeSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Downgrades an existing subscription to a lower tier.
        /// </summary>
        /// <param name="command">The command containing downgrade details.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPost]
        [Route("downgrade")]
        public IActionResult DowngradeSubscription([FromBody] DowngradeSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancels an existing subscription.
        /// </summary>
        /// <param name="command">The command containing cancellation details.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPost]
        [Route("cancel")]
        public IActionResult CancelSubscription([FromBody] CancelSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the payment status of a specific subscription.
        /// </summary>
        /// <param name="query">The query containing the subscription ID.</param>
        /// <returns>A <see cref="PaymentStatusResponse"/> with the subscription's payment status.</returns>
        [HttpGet]
        [Route("{subscriptionId}/status")]
        public ActionResult<PaymentStatusResponse> GetSubscriptionStatus([FromRoute]GetSubscriptionStatusQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
