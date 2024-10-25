namespace DittoBox.API.UserProfile.Application.DTOs
{
    public record UserResource (
		int Id,
		string Username,
		string Email
	);
}