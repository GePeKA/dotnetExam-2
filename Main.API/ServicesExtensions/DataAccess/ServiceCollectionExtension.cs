using Domain.Abstractions.Repositories;
using Main.DataAccess.Repositories;

namespace Main.API.ServicesExtensions.DataAccess;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
    {
        return services
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IGameSessionRepository, GameSessionRepository>();
    }
}
