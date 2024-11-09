using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Handlers.Internal;
using DittoBox.API.AccountSubscription.Application.Services;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.AccountSubscription.Infrastructure.Repositories;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Handlers.Internal;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Application.Services;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Infrastructure.Repositories;
using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.GroupManagement.Domain.Services.Application;
using DittoBox.API.GroupManagement.Domain.Services.Domain;
using DittoBox.API.GroupManagement.Infrastructure.Repositories;
using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Handlers.Internal;
using DittoBox.API.UserProfile.Application.Services;
using DittoBox.API.UserProfile.Domain.Repositories;
using DittoBox.API.UserProfile.Domain.Services.Application;
using DittoBox.API.UserProfile.Infrastructure.Repositories;
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

            var postgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

            if (string.IsNullOrEmpty(postgresConnectionString))
            {
                postgresConnectionString = builder.Configuration.GetConnectionString("POSTGRES_CONNECTION_STRING");
            }
            if (string.IsNullOrEmpty(postgresConnectionString))
            {
                throw new ArgumentException("PostgreSQL connection string is not configured.");
            }

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(
                    postgresConnectionString
                )
            );

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			RegisterHandlers(builder);
            RegisterRepositories(builder);
            RegisterServices(builder);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            // Reset database
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                // db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
		
	    app.UseCors("AllowAll");
            
	    app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    
		public static void RegisterHandlers(WebApplicationBuilder builder)
		{
            /* UserProfile handlers */
			builder.Services.AddScoped<ICreateUserCommandHandler, CreateUserCommandHandler>();
            builder.Services.AddScoped<IGetUserQueryHandler, GetUserQueryHandler>();
            builder.Services.AddScoped<IDeleteUserCommandHandler, DeleteUserCommandHandler>();
            builder.Services.AddScoped<IChangePasswordCommandHandler, ChangePasswordCommandHandler>();
            builder.Services.AddScoped<IGetProfileDetailsQueryHandler, GetProfileDetailsQueryHandler>();
            builder.Services.AddScoped<IGrantPrivilegeCommandHandler, GrantPrivilegeCommandHandler>();
            builder.Services.AddScoped<IRevokePrivilegeCommandHandler, RevokePrivilegeCommandHandler>();
            builder.Services.AddScoped<IUpdateProfileNamesCommandHandler, UpdateProfileNamesCommandHandler>();
            builder.Services.AddScoped<ILoginCommandHandler, LoginCommandHandler>();

            /* AccountSubscription handlers */
            builder.Services.AddScoped<ICreateAccountCommandHandler, CreateAccountCommandHandler>();
            builder.Services.AddScoped<IDeleteAccountCommandHandler, DeleteAccountCommandHandler>();
            builder.Services.AddScoped<IGetAccountDetailsQueryHandler, GetAccountDetailsQueryHandler>();
            builder.Services.AddScoped<IUpdateAccountCommandHandler, UpdateAccountCommandHandler>();
            builder.Services.AddScoped<IUpdateBusinessInformationCommandHandler, UpdateBusinessInformationCommandHandler>();
            builder.Services.AddScoped<ICancelSubscriptionCommandHandler, CancelSubscriptionCommandHandler>();
            builder.Services.AddScoped<IDowngradeSubscriptionCommandHandler, DowngradeSubscriptionCommandHandler>();
            builder.Services.AddScoped<IUpgradeSubscriptionCommandHandler, UpgradeSubscriptionCommandHandler>();
            builder.Services.AddScoped<IGetSubscriptionDetailsQueryHandler, GetSubscriptionDetailsQueryHandler>();
            builder.Services.AddScoped<ICancelSubscriptionCommandHandler, CancelSubscriptionCommandHandler>();
			builder.Services.AddScoped<IGetSubscriptionUsageQueryHandler, getSubscriptionUsageQueryHandler>();

            /* Container Management handlers */
            builder.Services.AddScoped<ICreateContainerCommandHandler, CreateContainerCommandHandler>();
            builder.Services.AddScoped<IGetContainerQueryHandler, GetContainerQueryHandler>();
            builder.Services.AddScoped<IGetContainerStatusByContainerIdQueryHandler, GetContainerStatusByContainerIdQueryHandler>();
            builder.Services.AddScoped<IGetHealthStatusByContainerIdQueryHandler, GetHealthStatusByContainerIdQueryHandler>();
            builder.Services.AddScoped<IUpdateContainerMetricsCommandHandler, UpdateContainerMetricsCommandHandler>();
            builder.Services.AddScoped<IUpdateContainerParametersCommandHandler, UpdateContainerParametersCommandHandler>();
            builder.Services.AddScoped<IUpdateContainerStatusCommandHandler, UpdateContainerStatusCommandHandler>();
            builder.Services.AddScoped<IUpdateHealthStatusCommandHandler, UpdateHealthStatusCommandHandler>();
			builder.Services.AddScoped<IGetContainersQueryHandler, GetContainersQueryHandler>();
			builder.Services.AddScoped<IGetTemplateQueryHandler, GetTemplateQueryHandler>();
			builder.Services.AddScoped<ICreateTemplateCommandHandler, CreateTemplateCommandHandler>();
			builder.Services.AddScoped<IGetTemplatesQueryHandler, GetTemplatesQueryHandler>();

            /* GroupManagement handlers */
            builder.Services.AddScoped<ICreateGroupCommandHandler, CreateGroupCommandHandler>();
            builder.Services.AddScoped<IGetGroupQueryHandler, GetGroupQueryHandler>();
            builder.Services.AddScoped<IRegisterUserCommandHandler, RegisterUserCommandHandler>();
            builder.Services.AddScoped<IRegisterContainerCommandHandler, RegisterContainerCommandHandler>();
        }

        public static void RegisterRepositories(WebApplicationBuilder builder) {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            builder.Services.AddScoped<IProfilePrivilegeRepository, ProfilePrivilegeRepository>();
            builder.Services.AddScoped<IContainerRepository, ContainerRepository>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
			builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
        }

        public static void RegisterServices(WebApplicationBuilder builder) {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
            builder.Services.AddScoped<IContainerService, ContainerService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
			builder.Services.AddScoped<ITemplateService, TemplateService>();
        }
	}
}
