using DittoBox.API.UserProfile.Application.Resources;
using DittoBox.API.UserProfile.Domain.Models.Entities;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public interface IGetUsersByAccountIdQueryHandler
    {
        Task<IEnumerable<ProfileResource>> Handle(GetUsersByAccountIdQuery query);
    }
}