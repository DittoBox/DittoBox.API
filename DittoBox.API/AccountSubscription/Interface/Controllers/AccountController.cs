using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController(
        ILogger<AccountController> _logger,
        ICreateAccountCommandHandler createAccountCommandHandler,
        IGetAccountDetailsQueryHandler getAccountDetailsQueryHandler,
        IUpdateAccountCommandHandler updateAccountCommandHandler,
        IDeleteAccountCommandHandler deleteAccountCommandHandler,
        IUpdateBusinessInformationCommandHandler updateBusinessInformationCommandHandler
        ) : ControllerBase
    {
        [HttpGet]
        [Route("{accountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountResource>> GetAccountDetails([FromRoute] int accountId)
		{
			var query = new GetAccountDetailsQuery(accountId);

            try
            {
                var response = await getAccountDetailsQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting account with accountId: {accountId}", query.AccountId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountResource>> CreateAccount([FromBody] CreateAccountCommand command)
        {
            try
            {
                var response = await createAccountCommandHandler.Handle(command);
                return Created("", response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating account with businessName {businessName}.", command.BusinessName);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountResource>> UpdateAccount([FromBody] UpdateAccountCommand command)
        {
            try
            {
                await updateAccountCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating account with accountId: {AccountId}", command.AccountId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("{command:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAccount([FromRoute] DeleteAccountCommand command)
        {
            try
            {
                await deleteAccountCommandHandler.Handle(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting account with accountId: {AccountId}", command.AccountId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("{accountId:int}/business")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AccountResource>> UpdateBusinessName([FromRoute] int accountId ,[FromBody]UpdateBusinessInformationCommand command)
        {
            try
            {
                if (command.AccountId != accountId)
                {
                    return BadRequest();
                }
                await updateBusinessInformationCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating business information for account with accountId: {AccountId}", command.AccountId);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}