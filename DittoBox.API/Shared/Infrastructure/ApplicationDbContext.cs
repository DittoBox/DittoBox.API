using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.Shared.Infrastructure
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
        public DbSet<User> Users { get; set; }
		public DbSet<Profile> Profiles { get; set; }
		public DbSet<Account> Accounts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

    }
}