using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.UserProfile.Application.Queries
{
    public record ChangePasswordQuery(
        [Required, StringLength(64), EmailAddress] string Email
    );
}