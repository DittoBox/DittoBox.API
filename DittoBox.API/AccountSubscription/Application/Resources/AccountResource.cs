using System.ComponentModel.DataAnnotations;
using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;

namespace DittoBox.API.AccountSubscription.Application.Resources
{
	public record AccountResource
	(
		[Required] int Id,
		[Required] string BusinessName,
		[Required] string BussinessId,
		[Required] int RepresentativeId,
		[Required] int SubscriptionId)
	{
		public static AccountResource FromAccount(Account account)
		{
			return new AccountResource(
				account.Id, 
				account.BusinessName, 
				account.BussinessId, 
				account.RepresentativeId, 
				account.SubscriptionId
			);
		}


	}
}