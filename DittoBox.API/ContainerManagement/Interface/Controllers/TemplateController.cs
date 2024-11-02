using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TemplateController : ControllerBase
    {
        [HttpPost]
        public Task<ActionResult<TemplateResource>> CreateTemplate([FromBody] CreateTemplateCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{templateId}")]
        public Task<ActionResult> DeleteTemplate([FromRoute] int templateId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{templateId}")]
        public Task<ActionResult<TemplateResource>> UpdateTemplate([FromRoute] int templateId, [FromBody] UpdateTemplateCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{templateId}")]
        public Task<ActionResult<TemplateResource>> GetTemplate([FromRoute] int templateId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<TemplateResource>>> GetTemplates()
        {
            throw new NotImplementedException();
        }
    }
}
