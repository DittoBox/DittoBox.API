using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Interface.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
    /// <summary>
    /// Controller for managing account operations.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// Retrieves account details based on the provided query.
        /// </summary>
        /// <param name="query">The query parameters for fetching account details.</param>
        /// <returns>An <see cref="AccountResponse"/> containing the account details.</returns>
        [HttpGet]
        [Route("{query}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<AccountResponse>> GetAccountDetails([FromRoute] GetAccountDetailsQuery query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new account with the specified details.
        /// </summary>
        /// <param name="command">The command containing account creation parameters.</param>
        /// <returns>An <see cref="AccountResponse"/> representing the created account.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<AccountResponse>> CreateAccount([FromBody] CreateAccountCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing account with new information.
        /// </summary>
        /// <param name="accountId">The ID of the account to update.</param>
        /// <param name="command">The command containing updated account information.</param>
        /// <returns>An <see cref="AccountResponse"/> representing the updated account.</returns>
        [HttpPut]
        [Route("{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<AccountResponse>> UpdateAccount([FromRoute] int accountId, [FromBody] UpdateAccountCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an account with the specified ID.
        /// </summary>
        /// <param name="accountId">The ID of the account to delete.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the operation.</returns>
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

        /// <summary>
        /// Updates the business information of a specific account.
        /// </summary>
        /// <param name="accountId">The ID of the account to update.</param>
        /// <param name="command">The command containing the new business information.</param>
        /// <returns>An <see cref="AccountResponse"/> representing the updated account.</returns>
        [HttpPut]
        [Route("{accountId}/business")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<AccountResponse>> UpdateBusinessName([FromRoute]int accountId ,[FromBody]UpdateBusinessInformationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
