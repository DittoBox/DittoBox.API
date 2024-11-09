using DittoBox.API.UserProfile.Domain.Models.Entities;

namespace DittoBox.API.UserProfile.Application.Resources
{
	public record ProfileResource
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public int? AccountId { get; set; }
		public int? GroupId { get; set; }
		public ICollection<string> ProfilePrivileges { get; set; } = [];


		public static ProfileResource FromProfile(Profile profile)
		{
			return new ProfileResource()
			{
				FirstName = profile.FirstName,
				LastName = profile.LastName,
				AccountId = profile.AccountId,
				GroupId = profile.GroupId,
				ProfilePrivileges = profile.ProfilePrivileges.Select(pp => pp.Privilege.ToString()).ToList()
			};
		}
	}
}