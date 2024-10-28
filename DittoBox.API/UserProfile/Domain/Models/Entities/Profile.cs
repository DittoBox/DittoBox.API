using DittoBox.API.UserProfile.Domain.Models.ValueObjects;

namespace DittoBox.API.UserProfile.Domain.Models.Entities {
	public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Privilege? ProfilePrivilege { get; set; }
        public Profile()
        {
        }

        public Profile(int userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
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