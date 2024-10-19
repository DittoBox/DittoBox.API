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
		public ActionResult<UserDto> GetUserDetails([FromRoute] GetUserQuery userId)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public ActionResult<UserDto> CreateUser([FromBody] CreateUserCommand user)
		{
			throw new NotImplementedException();
		}

		[HttpDelete]
		public ActionResult DeleteUser([FromRoute] DeleteUserCommand userId)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public ActionResult RequestPasswordChange([FromBody] PasswordChangeQuery changePassword)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		public ActionResult ChangePassword([FromBody] PasswordChangeCommand changePassword)
		{
			throw new NotImplementedException();
		}
	}
}