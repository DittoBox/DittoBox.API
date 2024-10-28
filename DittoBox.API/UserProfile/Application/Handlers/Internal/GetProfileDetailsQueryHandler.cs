using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Queries;
using DittoBox.API.UserProfile.Application.Resources;
using DittoBox.API.UserProfile.Domain.Repositories;
using DittoBox.API.UserProfile.Domain.Services.Application;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class GetProfileDetailsQueryHandler(
        IProfileService profileService
        ) : IGetProfileDetailsQueryHandler
    {
        public async Task<ProfileResource?> Handle(GetProfileQuery query)
        {
            var result = await profileService.GetProfile(query.ProfileId);
            return result == null ? null : ProfileResource.FromProfile(result);
        }
    }
}
