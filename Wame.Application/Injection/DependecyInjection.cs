using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wame.Application.Implementation.Auth;
using Wame.Application.Implementation.Campaigns;
using Wame.Application.Implementation.Recruiters;
using Wame.Application.Implementation.Tokens;

namespace Wame.Application.Injection;

public static class DependecyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
    
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMappings();
        
        services.AddTransient<TokenService>();
        services.AddTransient<AuthService>();
        services.AddTransient<CampaignService>();
        services.AddTransient<RecruiterRepository>();
        services.AddTransient<CampaignRepository>();

        return services;
    }
}