namespace Main.API.ServicesExtensions.Cors;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCorsWithFrontendPolicy(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy(name: "Frontend",
                policy =>
                {
                    policy.WithOrigins(configuration["FrontendConfig:Url"]!)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });

        return serviceCollection;
    }
}
