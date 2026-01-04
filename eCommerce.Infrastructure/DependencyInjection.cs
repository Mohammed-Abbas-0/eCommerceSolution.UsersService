using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Context;
using eCommerce.Infrastructure.Repositories;
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
        services.AddScoped<IUserRepository,UserRepository>();

        // Register Dapper DbContext
        services.AddScoped<IDbConnection>(sp =>
        {
            var connectionString = configuration
                .GetConnectionString("PostgreConnectionString");

            return new NpgsqlConnection(connectionString);
        });

        services.AddScoped<DapperDbContext>();

        return services;
    }
}

