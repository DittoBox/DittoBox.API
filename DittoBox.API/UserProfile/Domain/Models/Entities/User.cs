using DittoBox.API.UserProfile.Domain.Models.ValueObjects;

namespace DittoBox.API.UserProfile.Domain.Models.Entities
{
	public class User(string username, string password, string email)
	{
		public int Id { get; set; }
		public string Username { get; set; } = username;
		public string Password { get; set; } = password;
		public string Email { get; set; } = email;

		public string GetUserDetails() {
			throw new NotImplementedException();
		}

		public void UpdateUsername(string username) {
			throw new NotImplementedException();
		}

		public void UpdateEmail(string email) {
			throw new NotImplementedException();
		}

		public void UpdatePassword(string password) {
			throw new NotImplementedException();
		}
	}
}