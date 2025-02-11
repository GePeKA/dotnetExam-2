using Main.API.Configurations;
using MassTransit;

namespace Main.API.ServicesExtensions.MassTransit
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection services,
        RabbitMqConfig rabbitConfiguration)
        {
            return services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(rabbitConfiguration.Hostname!), h =>
                    {
                        h.Username(rabbitConfiguration.Username);
                        h.Password(rabbitConfiguration.Password);
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });
        }
    }
}
