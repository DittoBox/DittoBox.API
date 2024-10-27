using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        [HttpGet]
        [Route("{subscriptionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResource))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubscriptionResource> GetSubscriptionDetails([FromRoute]GetSubscriptionDetailsQuery query)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("upgrade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResource))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubscriptionResource> UpgradeSubscription([FromBody] UpgradeSubscriptionCommand command)
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
        public ActionResult<PaymentStatusResource> GetSubscriptionStatus([FromRoute]GetSubscriptionStatusQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
