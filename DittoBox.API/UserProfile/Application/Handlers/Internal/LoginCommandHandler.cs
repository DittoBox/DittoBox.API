using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class LoginCommandHandler(
        
    ) : ILoginCommandHandler
    {
        public async Task Handle(LoginCommand command)
        {

        }
    }
}
