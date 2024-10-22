using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.GroupManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GroupController : ControllerBase
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
    }
}
