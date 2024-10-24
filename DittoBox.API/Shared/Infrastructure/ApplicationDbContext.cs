using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.Shared.Infrastructure
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

	}
}