using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Resources;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class CreateAccountCommandHandler(
		IAccountService accountService,
		IUnitOfWork unitOfWork
	) : ICreateAccountCommandHandler
    {
        public async Task<AccountResource> Handle(CreateAccountCommand command)
        {
			var result = await accountService.CreateAccount(command.RepresentativeId, command.BusinessName, command.BusinessId);
			await unitOfWork.CompleteAsync();
			return AccountResource.FromAccount(result);
        }
    }
}
