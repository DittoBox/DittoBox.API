using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    /// <summary>
    /// Controller for managing containers.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContainerController : ControllerBase
    {
        /// <summary>
        /// Creates a new container.
        /// </summary>
        /// <param name="command">The command containing container creation parameters.</param>
        /// <returns>A <see cref="ContainerResource"/> representing the created container.</returns>
        [HttpPost]
        public Task<ActionResult<ContainerResource>> CreateContainer([FromBody]CreateContainerCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assigns a template to an existing container.
        /// </summary>
        /// <param name="containerId">The ID of the container.</param>
        /// <param name="templateId">The ID of the template to assign.</param>
        /// <returns>A <see cref="ContainerResource"/> representing the updated container.</returns>
        [HttpPost]
        [Route("{containerId}/assign/{templateId}")]
        public Task<ActionResult<ContainerResource>> AssignTemplate([FromRoute] int containerId, [FromRoute] int templateId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the status of a specific container.
        /// </summary>
        /// <param name="containerId">The ID of the container.</param>
        /// <returns>A <see cref="ContainerStatusResource"/> representing the container's status.</returns>
        [HttpGet]
        [Route("{containerId}/status")]
        public Task<ActionResult<ContainerStatusResource>> GetContainerStatus([FromRoute] int containerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the health information of a specific container.
        /// </summary>
        /// <param name="containerId">The ID of the container.</param>
        /// <returns>A <see cref="ContainerHealthResource"/> representing the container's health.</returns>
        [HttpGet]
        [Route("{containerId}/health")]
        public Task<ActionResult<ContainerHealthResource>> GetContainerHealth([FromRoute] int containerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the parameters of an existing container.
        /// </summary>
        /// <param name="containerId">The ID of the container to update.</param>
        /// <param name="command">The command containing updated parameters.</param>
        /// <returns>A <see cref="ContainerResource"/> representing the updated container.</returns>
        [HttpPut]
        [Route("{containerId}")]
        public Task<ActionResult<ContainerResource>> UpdateContainerParameters([FromRoute] int containerId, [FromBody] UpdateContainerParametersCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
