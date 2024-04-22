using Auth.Core.Entities;
using Auth.Infrastructure.DataContext;
using Auth.Infrastructure.Repositories;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure;

public static class ConfigurationServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepositoryBase<>) , typeof(RepositoryBase<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        var connection = configuration.GetConnectionString("ConnectionString");
        services.AddDbContext<AppDbContext>(option =>option.UseNpgsql(connection));
        
        DbContextInitializer.Init(services.BuildServiceProvider().GetRequiredService<AppDbContext>());

        return services;
    }
}