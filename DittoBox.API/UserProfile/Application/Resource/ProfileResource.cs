namespace DittoBox.API.UserProfile.Application.DTOs
{
    public record ProfileResource (
		int Id,
		string FirstName,
		string LastName
	);
}