using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.UserProfile.Application.Commands
{
    public record ChangePasswordCommand(
        [Required, StringLength(64), EmailAddress] string Email,
        [Required, StringLength(64, MinimumLength = 8)] string NewPassword
        );
}