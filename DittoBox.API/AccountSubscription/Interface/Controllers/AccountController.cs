using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Interface.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        [Route("{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<AccountResponse>> GetAccountDetails([FromRoute] GetAccountDetailsQuery query)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<AccountResponse>> CreateAccount([FromBody] CreateAccountCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<AccountResponse>> UpdateAccount([FromRoute] int accountId, [FromBody] UpdateAccountCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{accountId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult> DeleteAccount([FromRoute] int accountId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{accountId}/business")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<AccountResponse>> UpdateBusinessName([FromRoute]int accountId ,[FromBody]UpdateBusinessInformationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}