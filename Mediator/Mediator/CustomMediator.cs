using Mediator.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Mediator
{
    public class CustomMediator(IServiceProvider serviceProvider) : IMediator
    {
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            Type handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            dynamic handler = serviceProvider.GetService(handlerType)!;

            return await handler.Handle((dynamic)request, cancellationToken);
        }

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest
        {
            var handler = serviceProvider.GetService<IRequestHandler<TRequest>>()!;

            return handler.Handle(request, cancellationToken);
        }
    }
}
