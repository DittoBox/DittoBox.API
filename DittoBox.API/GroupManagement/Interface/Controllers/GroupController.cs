using System.Text.Json;
using System.Text.Json.Serialization;
using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal;
using DittoBox.API.GroupManagement.Domain.Models.Queries;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.GroupManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GroupController (
        ICreateGroupCommandHandler createGroupCommandHandler,
        ILogger<GroupController> _logger,
        IGetGroupQueryHandler getGroupQueryHandler
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
        [Route("{groupId:int}")]
        public async Task<ActionResult<GroupResource>> GetGroup([FromRoute] int groupId)
        {
            try
            {
                var query = new GetGroupQuery(groupId);
                var response = await getGroupQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting group with groupId: {groupId}", groupId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create-group")]
        public async Task<ActionResult<GroupResource>> CreateGroup([FromBody] CreateGroupCommand command)
        {
            try
            {
                var response = await createGroupCommandHandler.Handle(command);
                _logger.LogInformation("Group created with name {name} and id {id}", response.Name, response.Id);
                return CreatedAtAction(nameof(GetGroup), new { GroupId = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating group with name {name}", command.Name);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
