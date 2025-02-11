using Domain.Abstractions.Repositories;
using Domain.Entities;
using Shared.CQRS.Queries;
using Shared.DTO;

namespace Main.Features.GameSessions.Queries.GetGameSession
{
    public class GetGameSessionQueryHandler(
        IGameSessionRepository gameRepository) : IQueryHandler<GetGameSessionQuery, GameSession>
    {
        public async Task<Result<GameSession>> Handle(GetGameSessionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var gameSession = await gameRepository.GetGameSessionAsync(request.Id);

                return new Result<GameSession>(gameSession, true);
            }
            catch (Exception ex)
            {
                return new Result<GameSession>(null, false, ex.Message);
            }
        }
    }
}
