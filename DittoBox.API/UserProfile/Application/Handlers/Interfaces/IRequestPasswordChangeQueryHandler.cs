using DittoBox.API.UserProfile.Application.Queries;

namespace DittoBox.API.UserProfile.Application.Handlers.Interfaces
{
    public interface IRequestPasswordChangeQueryHandler
    {
        public Task Handle(ChangePasswordQuery query);
    }
}
