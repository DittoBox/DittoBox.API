namespace DittoBox.API.UserProfile.Application.Resources
{
    public record UserResource (
		int Id,
		string Username,
		string Email
	);
}