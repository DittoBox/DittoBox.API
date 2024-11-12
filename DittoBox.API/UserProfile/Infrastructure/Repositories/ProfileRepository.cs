using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Repositories;

namespace DittoBox.API.UserProfile.Infrastructure.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Task<IEnumerable<Profile>> GetByAccountId(int accountId)
        {
            return Task.FromResult(_context.Set<Profile>().Where(p => p.AccountId == accountId).AsEnumerable());
        }
    }
}
