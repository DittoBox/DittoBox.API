using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Resources
{
    public record AccountResource
    (
        [Required] int Id,
        [Required] string BusinessName,
        [Required] int BussinessId,
        [Required] int RepresentativeId,
        [Required] int SubscriptionId
        );
}