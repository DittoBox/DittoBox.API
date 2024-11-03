using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TemplateController(
		ILogger<TemplateController> _logger,
		ICreateTemplateCommandHandler createTemplateCommandHandler,
		IDeleteTemplateCommandHandler deleteTemplateCommandHandler,
		IUpdateTemplateCommandHandler updateTemplateCommandHandler,
		IGetTemplateQueryHandler getTemplateQueryHandler,
        IGetTemplatesQueryHandler getTemplatesQueryHandler
	) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<TemplateResource>> CreateTemplate([FromBody] CreateTemplateCommand command)
        {
			var response = await createTemplateCommandHandler.Handle(command);
			return Created("", response);
        }

        [HttpDelete]
        [Route("{templateId}")]
        public async Task<ActionResult> DeleteTemplate([FromRoute] DeleteTemplateCommand command)
        {
			try
			{
				await deleteTemplateCommandHandler.Handle(command);
				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "And error ocurred while deleting template with id {templateId}", command.TemplateId);
				return StatusCode(500, "Internal server error");
			}
        }

        [HttpPut]
        [Route("{templateId}")]
        public Task<ActionResult<TemplateResource>> UpdateTemplate([FromRoute] int templateId, [FromBody] UpdateTemplateCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{templateId}")]
        public async Task<ActionResult<TemplateResource>> GetTemplate([FromRoute] GetTemplateQuery query)
        {
			try
            {
                var response = await getTemplateQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting template with templateId: {templateId}", query.TemplateId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemplateResource>>> GetTemplates()
        {
			try
			{
				var response = await getTemplatesQueryHandler.Handle();
				return response;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error ocurred while getting templates.");
				return StatusCode(500, "Internal server error");
			}
        }
    }
}
