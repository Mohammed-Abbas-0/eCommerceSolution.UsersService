using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repositories;
using eCommerce.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register repositories
        // User Repository
        // Register repositories
        // User Repository
        services.AddScoped<IUserRepository, UserRepository>();
        
        // Register Services
        services.AddTransient<IUserService, UserService>();

        // Register Dapper DbContext
        services.AddScoped<IDbConnection>(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            string? template = config.GetConnectionString("PostgresConnectionString");

            if (string.IsNullOrEmpty(template))
            {
                throw new Exception("Connection string 'PostgresConnectionString' is missing from appsettings.json!");
            }

            string host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "postgres";
            string pwd  = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "admin";
            string db   = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "eCommerceUsers";
            string user = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
            string port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";

            //string connectionString = template
            //                        .Replace("$POSTGRES_HOST", host)
            //                        .Replace("$POSTGRES_PORT", port)
            //                        .Replace("$POSTGRES_DB", db)
            //                        .Replace("$POSTGRES_USER", user)
            //                        .Replace("$POSTGRES_PASSWORD", pwd);
            string connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={pwd};Include Error Detail=true;";

            return new NpgsqlConnection(connectionString);
        });

        services.AddScoped<DapperDbContext>();

        return services;
    }
}

