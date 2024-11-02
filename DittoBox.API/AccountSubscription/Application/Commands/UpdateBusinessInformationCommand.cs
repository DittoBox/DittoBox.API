using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record UpdateBusinessInformationCommand
    (
        [Required] int AccountId,
        string? BusinessName,
        string? BusinessId
        );
}