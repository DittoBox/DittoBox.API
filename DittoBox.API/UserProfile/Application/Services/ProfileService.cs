using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Repositories;
using DittoBox.API.UserProfile.Domain.Services.Application;

namespace DittoBox.API.UserProfile.Application.Services
{
    public class ProfileService(
        IProfileRepository profileRepository
        ) : IProfileService
    {
        public async Task<Profile> CreateProfile(int userId, string firstname, string lastname)
        {
            var profile = new Profile(userId, firstname, lastname);
            await profileRepository.Add(profile);
            return profile;
        }
    }
}
