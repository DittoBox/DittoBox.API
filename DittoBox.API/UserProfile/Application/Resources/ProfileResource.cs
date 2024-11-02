using DittoBox.API.UserProfile.Domain.Models.Entities;

namespace DittoBox.API.UserProfile.Application.Resources
{
	public record ProfileResource(
		int Id,
		string FirstName,
		string LastName
	)
	{
		public static ProfileResource FromProfile(Profile profile)
        {
            return new ProfileResource(profile.Id, profile.FirstName, profile.LastName);
        }
    }
}