using System;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectData.Repositories;
using hackatonBackend.ProjectServices.Services.Common.Auth;
using hackatonBackend.WebApi.Middleware;
using HackBackend.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace hackatonBackend.Configuration.Extensions
{
    public static class ServiceCollection
    {
        private const string CorsPolicy = "AllowAllOrigins";

        public static void AddSetup(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = GetConnectionString(configuration);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionString));

            services.AddControllers()
           .ConfigureApiBehaviorOptions(options =>
           {
               options.SuppressModelStateInvalidFilter = true;
           });

            services.AddEndpointsApiExplorer();

            services.AddServices();
            
            services.AddJwtAuthorization(configuration);
            //services.AddDataAccess(configuration);

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("HackatonDatabase");
        }
    }
}

