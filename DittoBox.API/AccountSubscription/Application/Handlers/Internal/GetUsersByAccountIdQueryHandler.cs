using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.UserProfile.Application.Resources;
using DittoBox.API.UserProfile.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class GetUsersByAccountIdQueryHandler(
        IProfileService profileService
    ) : IGetUsersByAccountIdQueryHandler
    {
        public async Task<IEnumerable<ProfileResource>> Handle(GetUsersByAccountIdQuery query)
        {
            var result = await profileService.GetProfilesByAccountId(query.AccountId);
            return result.Select(ProfileResource.FromProfile);
        }
    }
}