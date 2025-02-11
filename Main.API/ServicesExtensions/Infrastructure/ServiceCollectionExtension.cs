using Main.Infrastructure.Options;
using Main.Infrastructure.Services.Abstractions;
using Main.Infrastructure.Services.Implementations;
using Main.Infrastructure.UnitOfWork;

namespace Main.API.ServicesExtensions.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

        services.AddTransient<IHasherService, HasherService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
