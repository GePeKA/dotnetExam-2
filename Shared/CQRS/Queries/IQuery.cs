using Mediator.Request;
using Shared.DTO;

namespace Shared.CQRS.Queries
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    { }
}
