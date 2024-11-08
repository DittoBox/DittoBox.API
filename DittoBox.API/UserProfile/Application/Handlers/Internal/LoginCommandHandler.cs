using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Resources;
using DittoBox.API.UserProfile.Domain.Services.Application;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class LoginCommandHandler(
        IUserService userService
    ) : ILoginCommandHandler
    {
        public async Task<LoginResource?> Handle(LoginCommand command)
        {
            var user = await userService.GetUserByEmail(command.Email) ?? null;
            var token = await userService.Login(command.Email, command.Password) ?? null;
            if (user == null || token == null)
            {
                return null;
            }

            return new LoginResource()
            {
                UserId = user.Id,
                Username = user.Username,
                Token = token,
                AccountId = 1,
                GroupId = 1,
                ProfileId = user.Id
            };

        }
    }
}
