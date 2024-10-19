using DittoBox.API.UserProfile.Domain.Models.ValueObjects;

namespace DittoBox.API.UserProfile.Domain.Models.Entities {
	public class Profile(int userId, string firstName, string lastName, Privilege profilePrivilege)
	{
		public int Id { get; set; }
		private int UserId { get; set; } = userId;
		private string FirstName { get; set; } = firstName;
		private string LastName { get; set; } = lastName;
		private Privilege ProfilePrivilege { get; set; } = profilePrivilege;

		public string GetProfileDetails() {
			throw new NotImplementedException();
		}

		public void UpdateFirstName(string firstName) {
			throw new NotImplementedException();
		}

		public void UpdateLastName(string lastName) {
			throw new NotImplementedException();
		}

		public void AssignPrivilege(Privilege privilege) {
			throw new NotImplementedException();
		}

		public void RevokePrivilege(Privilege privilege) {
			throw new NotImplementedException();
		}
	}
}