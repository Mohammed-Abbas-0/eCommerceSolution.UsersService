using eCommerce.Core.Mappers;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        // Auto Mapper Configurations
        services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
        return services;
    }
}
