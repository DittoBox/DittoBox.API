using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContainerController(
        ILogger<ContainerController> _logger,
        ICreateContainerCommandHandler createContainerCommandHandler,
        IGetContainerQueryHandler getContainerQueryHandler,
        IGetContainerStatusByContainerIdQueryHandler getContainerStatusByContainerIdQueryHandler,
        IGetHealthStatusByContainerIdQueryHandler getHealthStatusByContainerIdQueryHandler,
        IUpdateContainerMetricsCommandHandler updateContainerMetricsCommandHandler,
        IUpdateContainerParametersCommandHandler updateContainerParametersCommandHandler,
        IUpdateContainerStatusCommandHandler updateContainerStatusCommandHandler,
        IUpdateHealthStatusCommandHandler updateHealthStatusCommandHandler,
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

        [HttpGet("{ContainerId:int}")]
        public async Task<ActionResult<ContainerResource>> GetContainerById([FromRoute] GetContainerByIdQuery query)
        {
            try
            {
                var response = await getContainerQueryHandler.Handle(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting containers with containerId: {containerId}", query.ContainerId);
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
        [Route("{ContainerId}/status")]
        public async Task<ActionResult<ContainerStatusResource>> GetContainerStatus([FromRoute] GetContainerStatusByContainerIdQuery query)
        {
            try
            {
                var response = await getContainerStatusByContainerIdQueryHandler.Handle(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting container status with containerId: {containerId}", query.ContainerId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{ContainerId}/health")]
        public async Task<ActionResult<ContainerHealthResource>> GetContainerHealth([FromRoute] GetHealthStatusByContainerIdQuery query)
        {
            try
            {
                var response = await getHealthStatusByContainerIdQueryHandler.Handle(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting container health with containerId: {containerId}", query.ContainerId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("{containerId}/status")]
        public async Task<ActionResult> UpdateContainerStatus([FromRoute] int containerId, [FromBody] UpdateContainerStatusCommand command)
        {
            try
            {
                await updateContainerStatusCommandHandler.Handle(containerId, command);
                _logger.LogInformation("Container status updated with containerId: {containerId}", containerId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating container status with containerId: {containerId}", containerId);
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpPut]
        [Route("{containerId}/health")]
        public async Task<ActionResult> UpdateHealthStatus([FromRoute] int containerId, [FromBody] UpdateHealthStatusCommand command)
        {
            try
            {
                await updateHealthStatusCommandHandler.Handle(containerId, command);
                _logger.LogInformation("Health status updated with containerId: {containerId}", containerId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Health status with containerId: {containerId}", containerId);
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpPut]
        [Route("{containerId}/metrics")]
        public async Task<ActionResult> UpdateContainerMetrics([FromRoute] int containerId, [FromBody] UpdateContainerMetricsCommand command)
        {
            try
            {
                await updateContainerMetricsCommandHandler.Handle(containerId, command);
                _logger.LogInformation("Container metrics updated with containerId: {containerId}", containerId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating container metrics with containerId: {containerId}", containerId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("{containerId}/parameters")]
        public async Task<ActionResult> UpdateContainerParameters([FromRoute] int containerId, [FromBody] UpdateContainerParametersCommand command)
        {
            try
            {
                await updateContainerParametersCommandHandler.Handle(containerId, command);
                _logger.LogInformation("Container parameters updated with containerId: {containerId}", containerId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating container parameters with containerId: {containerId}", containerId);
                return StatusCode(500, "Internal server error");
            }
        }

		[HttpGet]
		public async Task<ActionResult<ICollection<ContainerResource>>> GetContainers()
		{
			var query = new GetContainersQuery();
			try
			{
				var response = await getContainersQueryHandler.Handle(query);
				return Ok(response);
			} catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while getting containers.");
				return StatusCode(500, "Internal server error");
			}
		}
    }
}
