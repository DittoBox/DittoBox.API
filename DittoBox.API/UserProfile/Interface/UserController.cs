using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.DTOs;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Handlers.Internal;
using DittoBox.API.UserProfile.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Interface
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController(
        ILogger<UserController> _logger,
        ICreateUserCommandHandler createUserCommandHandler,
        IGetUserQueryHandler getUserQueryHandler
    ) : ControllerBase
    {

        [HttpGet("{query}")]
        public async Task<ActionResult<UserResource>> GetUser([FromRoute] GetUserQuery query)
        {
            try
            {
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
        [Route("{userId}")]
        public ActionResult DeleteUser([FromRoute] DeleteUserCommand userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{userId}/request-password-change")]
        public ActionResult RequestPasswordChange([FromBody] PasswordChangeQuery changePassword)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{userId}/change-password")]
        public ActionResult ChangePassword([FromBody] PasswordChangeCommand changePassword)
        {
            throw new NotImplementedException();
        }
    }
}