using Mediator.DependencyInjectionExtensions;

namespace RatingService.ServicesExtensions.Mediator
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomMediator(this IServiceCollection services)
        {
            return services.AddMediator(Features.Helpers.AssemblyReference.Assembly);
        }
    }
}
