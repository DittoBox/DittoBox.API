namespace DittoBox.API.Shared.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext context)
    {
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
