using Microsoft.Extensions.DependencyInjection;
using Wame.Application.Abstract;
using Wame.Application.Abstract.Users;
using Wame.Application.Implementation.Tokens;
using Wame.Application.Implementation.Users;

namespace Wame.Application.Injection;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ITokenService, TokenService>();
        
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserService, UserService>();

        return services;
    }
}