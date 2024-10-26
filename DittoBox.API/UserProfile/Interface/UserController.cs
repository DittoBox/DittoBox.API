using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Resources;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Interface
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController(
        ILogger<UserController> _logger,
        ICreateUserCommandHandler createUserCommandHandler,
        IGetUserQueryHandler getUserQueryHandler,
        IDeleteUserCommandHandler deleteUserCommandHandler,
        IRequestPasswordChangeQueryHandler requestPasswordChangeQueryHandler,
        IChangePasswordCommandHandler changePasswordCommandHandler
    ) : ControllerBase
    {

        [HttpGet("{query:int}")]
        public async Task<ActionResult<UserResource>> GetUser([FromRoute] GetUserQuery query)
        {
            try
            {
                if (query.UserId <= 0)
                {
                    return BadRequest("UserId must be a positive integer.");
                }
                var response = await getUserQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting user with userId: {userId}", query.UserId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserResource>> CreateUser([FromBody] CreateUserCommand user)
        {
            try
            {
                var response = await createUserCommandHandler.Handle(user);
                _logger.LogInformation("User created with username {username} and id {id}", response.Username, response.Id);
                return CreatedAtAction(nameof(GetUser), new { query = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating user with email {email} and username {username}", user.Email, user.Username);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("{command:int}")]
        public async Task<ActionResult> DeleteUser([FromRoute] DeleteUserCommand command)
        {
            try
            {
                await deleteUserCommandHandler.Handle(command);
                _logger.LogInformation("User with userId: {userId} deleted", command.UserId);
                return NoContent();
            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while deleting user with userId: {userId}", command.UserId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("request-password-change")]
        public async Task<ActionResult> RequestPasswordChange([FromBody] ChangePasswordQuery changePassword)
        {
            try
            {
                await requestPasswordChangeQueryHandler.Handle(changePassword);
                _logger.LogInformation("Password change requested for user with email {email}", changePassword.Email);
                return Ok();
            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while requesting password change for user with email {email}", changePassword.Email);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordCommand changePassword)
        {
            try
            {

                await changePasswordCommandHandler.Handle(changePassword);
                _logger.LogInformation("Password changed for user with email {email}", changePassword.Email);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}