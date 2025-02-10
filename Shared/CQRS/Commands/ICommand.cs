using Mediator.Request;
using Shared.DTO;

namespace Shared.CQRS.Commands
{
    public interface ICommand : IRequest<Result>
    { }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    { }
}
