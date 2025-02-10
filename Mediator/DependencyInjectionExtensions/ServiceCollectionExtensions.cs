using Mediator.Mediator;
using Mediator.Request;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mediator.DependencyInjectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] handlersAssemblies)
        {
            var requestHandlersAndInterfaces = GetHandlerTypesAndInterfaces(handlersAssemblies);

            foreach (var (handler, iface) in requestHandlersAndInterfaces)
            {
                services.AddTransient(iface, handler);
            }

            return services
                .AddTransient<IMediator, CustomMediator>();
        }

        private static List<(Type handler, Type iface)> GetHandlerTypesAndInterfaces(Assembly[] handlersAssemblies)
        {
            var requestHandlerTypes = handlersAssemblies.SelectMany(a => a.GetTypes())
                .Where(t => t
                    .GetInterfaces()
                    .Any(IsHandlerInterface))
                .ToList();

            var requestHandlersAndInterfaces = requestHandlerTypes
                .Select(handler => (
                    Handler: handler,
                    Interface: handler
                        .GetInterfaces()
                        .First(IsHandlerInterface)
                ))
                .ToList();

            return requestHandlersAndInterfaces;
        }

        private static bool IsHandlerInterface(Type i)
        {
            return i.IsGenericType
                && (i.GetGenericTypeDefinition() == typeof(IRequestHandler<>)
                || i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));
        }
    }
}
