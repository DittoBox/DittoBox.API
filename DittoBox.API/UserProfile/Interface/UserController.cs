using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.DTOs;
using DittoBox.API.UserProfile.Application.Handlers.Internal;
using DittoBox.API.UserProfile.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Interface
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class UserController(
		ILogger<UserController> _logger,
		ICreateUserCommandHandler createUserCommandHandler
	) : ControllerBase
	{

		[HttpGet("{userId}")]
		public async Task<ActionResult<UserResource>> GetUser([FromRoute] GetUserQuery userId)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<ActionResult<UserResource>> CreateUser([FromBody] CreateUserCommand user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var response = await createUserCommandHandler.Handle(user);
			return CreatedAtAction(nameof(GetUser), new { userId = response.Id }, response);
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