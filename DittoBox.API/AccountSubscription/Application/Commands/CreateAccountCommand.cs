using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record CreateAccountCommand
    (
        [Required] string BusinessName,
        [Required] int BusinessId,
        [Required] int RepresentativeId
    );
}