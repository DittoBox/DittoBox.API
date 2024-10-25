using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.DTOs;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
	public class CreateUserCommandHandler : ICreateUserCommandHandler
	{
		public Task<UserResource> Handle(CreateUserCommand command)
		{
			return Task.FromResult(new UserResource(1, "dcancho", "u20201f479"));
		}
	}
}