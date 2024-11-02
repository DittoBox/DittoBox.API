using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlertInstanceController : ControllerBase
    {
        [HttpPost]
        [Route("{alertInstanceId}/ack")]
        public Task<ActionResult<AlertResource>> AcknowledgeAlert([FromRoute]int alertId, [FromBody]AcknowledgeAlertCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{alertInstanceId}/dismiss")]
        public Task<ActionResult<AlertResource>> DismissAlert([FromRoute]int alertId, [FromBody]DismissAlertCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<AlertResource>>> GetActiveAlerts([FromBody]GetActiveAlertsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
