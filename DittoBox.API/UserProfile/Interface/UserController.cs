using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.DTOs;
using DittoBox.API.UserProfile.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Interface
{
    [ApiController]
	[Route("api/v1/[controller]")]
	public class UserController(
		ILogger<UserController> _logger
	) : ControllerBase
	{
		[HttpGet("{userId}")]
		public ActionResult<UserResource> GetUserDetails([FromRoute] GetUserQuery userId)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public ActionResult<UserResource> CreateUser([FromBody] CreateUserCommand user)
		{
			throw new NotImplementedException();
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