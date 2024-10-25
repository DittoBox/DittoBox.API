using DittoBox.API.UserProfile.Application.DTOs;
using DittoBox.API.UserProfile.Application.Queries;

namespace DittoBox.API.UserProfile.Application.Handlers.Interfaces
{
    public interface IGetUserQueryHandler
    {
        public Task<UserResource> Handle(GetUserQuery query);
    }
}