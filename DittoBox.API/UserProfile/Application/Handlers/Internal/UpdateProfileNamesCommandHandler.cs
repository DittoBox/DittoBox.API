using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;

namespace DittoBox.API.UserProfile.Application.Handlers.Internal
{
    public class UpdateProfileNamesCommandHandler : IUpdateProfileNamesCommandHandler
    {
        public Task Handle(UpdateProfileNamesCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
