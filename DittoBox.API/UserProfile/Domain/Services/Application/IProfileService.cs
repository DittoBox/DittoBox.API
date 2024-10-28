using DittoBox.API.UserProfile.Domain.Models.Entities;

namespace DittoBox.API.UserProfile.Domain.Services.Application
{
    public interface IProfileService
    {
        public Task<Profile> CreateProfile(int userId, string firstname, string lastname);

    }
}
