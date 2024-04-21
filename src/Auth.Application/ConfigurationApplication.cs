using System.Reflection;
using Auth.Application.AutoMapperProfile;
using Auth.Application.Security;
using Auth.Application.Security.Interfaces;
using Auth.Application.Services;
using Auth.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Application;

public static class ConfigurationApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<ITokenManager, TokenManager>();
        services.AddAutoMapper(typeof(AotoMapper));
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}