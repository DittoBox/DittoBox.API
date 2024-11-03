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
		IGetTemplateQueryHandler getTemplateQueryHandler,
        IGetTemplatesQueryHandler getTemplatesQueryHandler,
		ICreateTemplateCommandHandler createTemplateCommandHandler
	) : ControllerBase
    {
        [HttpGet]
        [Route("{templateId}")]
        public async Task<ActionResult<TemplateResource>> GetTemplate([FromRoute] int templateId)
        {
			var query = new GetTemplateQuery(templateId);
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
        public async Task<ActionResult<ICollection<TemplateResource>>> GetTemplates()
        {
			var query = new GetTemplatesQuery();
			try
			{
				var response = await getTemplatesQueryHandler.Handle(query);
				return Ok(response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error ocurred while getting templates.");
				return StatusCode(500, "Internal server error");
			}
        }

		[HttpPost]
		public async Task<ActionResult<TemplateResource>> CreateTemplate([FromBody] CreateTemplateCommand template) {
			try
			{
				var response = await createTemplateCommandHandler.Handle(template);
				_logger.LogInformation("Template created with name {name} and id {id}", response.Name, response.Id);
				return StatusCode(201, response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating template with name {name}", template.Name);
				return StatusCode(500, "Internal server error");
			}
		}
    }
}
