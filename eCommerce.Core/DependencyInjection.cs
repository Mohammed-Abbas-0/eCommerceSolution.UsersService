using eCommerce.Core.Mappers;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();

        // Fluent Validations
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        // Auto Mapper Configurations
        services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
        return services;
    }
}
