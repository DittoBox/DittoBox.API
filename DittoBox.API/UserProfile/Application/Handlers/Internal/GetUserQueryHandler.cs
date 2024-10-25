using DittoBox.API.UserProfile.Application.DTOs;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Queries;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class GetUserQueryHandler : IGetUserQueryHandler
    {
        public Task<UserResource> Handle(GetUserQuery query)
        {
            return Task.FromResult(new UserResource(1, "dcancho", "u20201f479"));
        }
    }
}
