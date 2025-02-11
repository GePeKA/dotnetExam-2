using MassTransit;
using RatingService.Configurations;
using RatingService.Consumers;

namespace RatingService.ServicesExtensions.MassTransit
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection services,
        RabbitMqConfig rabbitConfiguration)
        {
            return services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumer<RatingConsumer>();
                busConfigurator.AddConsumer<UserConsumer>();

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
