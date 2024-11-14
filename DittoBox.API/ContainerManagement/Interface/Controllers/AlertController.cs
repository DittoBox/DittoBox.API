using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    /// <summary>
    /// Controller for managing alert instances.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlertInstanceController : ControllerBase
    {
        /// <summary>
        /// Acknowledges a specific alert instance.
        /// </summary>
        /// <param name="alertId">The ID of the alert instance to acknowledge.</param>
        /// <param name="command">The command containing acknowledgment details.</param>
        /// <returns>An <see cref="AlertResource"/> representing the acknowledged alert.</returns>
        [HttpPost]
        [Route("{alertInstanceId}/ack")]
        public Task<ActionResult<AlertResource>> AcknowledgeAlert([FromRoute]int alertId, [FromBody]AcknowledgeAlertCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dismisses a specific alert instance.
        /// </summary>
        /// <param name="alertId">The ID of the alert instance to dismiss.</param>
        /// <param name="command">The command containing dismissal details.</param>
        /// <returns>An <see cref="AlertResource"/> representing the dismissed alert.</returns>
        [HttpPost]
        [Route("{alertInstanceId}/dismiss")]
        public Task<ActionResult<AlertResource>> DismissAlert([FromRoute]int alertId, [FromBody]DismissAlertCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all active alert instances based on the provided query.
        /// </summary>
        /// <param name="query">The query parameters for retrieving active alerts.</param>
        /// <returns>A collection of active <see cref="AlertResource"/> instances.</returns>
        [HttpGet]
        public Task<ActionResult<IEnumerable<AlertResource>>> GetActiveAlerts([FromBody]GetActiveAlertsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
