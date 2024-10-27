using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Queries;
using DittoBox.API.UserProfile.Application.Resources;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class GetProfileDetailsQueryHandler : IGetProfileDetailsQueryHandler
    {
        public Task<ProfileResource> Handle(GetProfileQuery query)
        {
            return Task.FromResult(new ProfileResource(1, "Diego", "Cancho"));
        }
    }
}
