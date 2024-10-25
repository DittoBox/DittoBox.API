using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.DTOs;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
	public interface ICreateUserCommandHandler
	{
		public Task<UserResource> Handle(CreateUserCommand command);
	}
}