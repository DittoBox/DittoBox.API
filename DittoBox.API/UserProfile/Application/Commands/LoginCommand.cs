using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.UserProfile.Application.Commands
{
    public record LoginCommand(
        [Required] string Username,
        [Required] string Password
    );
}
