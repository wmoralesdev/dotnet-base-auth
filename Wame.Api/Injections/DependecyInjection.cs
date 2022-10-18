using Microsoft.EntityFrameworkCore;
using Wame.Application.Context;

namespace Wame.Api.Injections;

public static class DependecyInjection
{
    public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("Default"),
                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                )
        );
        
        return services;
    }
}