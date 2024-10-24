using DittoBox.API.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Configuration.AddUserSecrets<Program>();

            var postgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? throw new ArgumentNullException("POSTGRES_CONNECTION_STRING environment variable is required");

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(
                    postgresConnectionString
                )
            );

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            // Reset database
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
