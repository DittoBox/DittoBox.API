using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Queries;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class RequestPasswordChangeQueryHandler : IRequestPasswordChangeQueryHandler
    {
        public Task Handle(ChangePasswordQuery query)
        {
            return Task.CompletedTask;
        }
    }
}
