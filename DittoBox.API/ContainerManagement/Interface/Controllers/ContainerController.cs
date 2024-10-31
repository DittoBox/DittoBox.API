using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContainerController(
        ILogger<ContainerController> _logger,
        ICreateContainerCommandHandler createContainerCommandHandler,
        IGetContainersQueryHandler getContainersQueryHandler
        ) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateContainerResource>> CreateContainer([FromBody] CreateContainerCommand container)
        {
            try
            {
                var response = await createContainerCommandHandler.Handle(container);
                _logger.LogInformation("Container created with name {name} and id {id}", response.Name, response.Id);
                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating container with name {name}", container.Name);
                return StatusCode(500, "Internal server error");
            }
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
