using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Interface.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        [HttpGet]
        [Route("{subscriptionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubscriptionResponse> GetSubscriptionDetails([FromRoute]GetSubscriptionDetailsQuery query)
        {
            throw new System.NotImplementedException();
        }

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

        [HttpPost]
        [Route("downgrade")]
        public IActionResult DowngradeSubscription([FromBody] DowngradeSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("cancel")]
        public IActionResult CancelSubscription([FromBody] CancelSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{subscriptionId}/status")]
        public ActionResult<PaymentStatusResponse> GetSubscriptionStatus([FromRoute]GetSubscriptionStatusQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
