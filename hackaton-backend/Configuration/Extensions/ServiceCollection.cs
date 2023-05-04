using System;
using Azure.Storage.Blobs;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectData.Repositories;
using hackatonBackend.ProjectServices.Services.Blob;
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
            var blobString = GetBlobImagesString(configuration);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionString));
            services.AddSingleton(blob => new BlobServiceClient(blobString));

            services.AddControllers()
           .ConfigureApiBehaviorOptions(options =>
           {
               options.SuppressModelStateInvalidFilter = true;
           });

            services.AddEndpointsApiExplorer();

            services.AddServices();
            
            services.AddJwtAuthorization(configuration);
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBlobService, BlobService>();
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("HackatonDatabase");
        }

        private static string GetBlobImagesString(IConfiguration configuration) {
            return configuration.GetConnectionString("AzureBlobImages");
        }
    }
}

