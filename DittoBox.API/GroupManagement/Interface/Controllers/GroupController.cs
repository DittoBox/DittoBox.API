using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Queries;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DittoBox.API.GroupManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GroupController (
        ICreateGroupCommandHandler createGroupCommandHandler,
        ILogger<GroupController> _logger
    ) : ControllerBase
    {

        [HttpPost]
        [Route("{groupId}/register-container")]
        public ActionResult RegisterContainer([FromRoute]int groupId, [FromBody]RegisterContainerCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{groupId}/unregister-container")]
        public void UnregisterContainer([FromRoute]int groupId, [FromBody]UnregisterContainerCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{groupId}/transfer-container")]
        public void TransferContainer([FromRoute] int groupId, [FromBody] TransferContainerCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{groupId}/register-user")]
        public void RegisterUser([FromRoute] int groupId, [FromBody] RegisterUserCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{groupId}/unregister-user")]
        public void UnregisterUser([FromRoute]int groupId, [FromBody]UnregisterUserCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{groupId}/transfer-user")]
        public void TransferUser([FromRoute]int groupId, [FromBody]TransferUserCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{groupId}/get-group-location")]
        public void GetGroupLocation([FromRoute]int groupId, [FromBody]GetGroupLocationQuery query)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{groupId}")]
        public ActionResult<GroupResource> GetGroup([FromRoute]int groupId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<GroupResource>> CreateGroup([FromBody] CreateGroupCommand command)
        {
            // try
            // {
            //     var response = await createGroupCommandHandler.Handle(command);
            //     _logger.LogInformation("Group created with name {name} and id {id}", response.Name, response.Id);
            //     return CreatedAtAction(nameof(GetGroup), new { GroupId = response.Id }, response);
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogError(ex, "An error occurred while creating group with name {name}", command.Name);
            //     return StatusCode(500, "Internal server error");
            // }
            try
            {
                var response = await createGroupCommandHandler.Handle(command);
                _logger.LogInformation("Group created with name {name} and id {id}", response.Name, response.Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating group with name {name}", command.Name);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
