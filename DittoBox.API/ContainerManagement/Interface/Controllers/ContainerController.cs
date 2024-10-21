using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContainerController : ControllerBase
    {
        [HttpPost]
        public Task<ActionResult<ContainerResource>> CreateContainer([FromBody]CreateContainerCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{containerId}/assign/{templateId}")]
        public Task<ActionResult<ContainerResource>> AssignTemplate([FromRoute] int containerId, [FromRoute] int templateId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{containerId}/status")]
        public Task<ActionResult<ContainerStatusResource>> GetContainerStatus([FromRoute] int containerId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{containerId}/health")]
        public Task<ActionResult<ContainerHealthResource>> GetContainerHealth([FromRoute] int containerId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{containerId}")]
        public Task<ActionResult<ContainerResource>> UpdateContainerParameters([FromRoute] int containerId, [FromBody] UpdateContainerParametersCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
