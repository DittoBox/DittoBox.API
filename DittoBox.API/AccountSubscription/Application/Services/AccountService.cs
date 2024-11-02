using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Services
{
	public class AccountService(
		IAccountRepository accountRepository
	) : IAccountService
	{
		public async Task<Account> CreateAccount(int representativeId, string businessName, string businessId)
		{
			var account = new Account(){
				RepresentativeId = representativeId,
				BusinessName = businessName,
				BussinessId = businessId
			};

			await accountRepository.Add(account);
			return account;
		}

		public async Task<Account?> GetAccount(int accountId)
		{
			return await accountRepository.GetById(accountId);
		}
	}
}
