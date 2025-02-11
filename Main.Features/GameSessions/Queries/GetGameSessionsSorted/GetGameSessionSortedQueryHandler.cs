using Domain.Abstractions.Repositories;
using Shared.CQRS.Queries;
using Shared.DTO;

namespace Main.Features.GameSessions.Queries.GetGameSessionsSorted;

public class GetGameSessionSortedQueryHandler(
    IGameSessionRepository gameRepository) : IQueryHandler<GetGameSessionSortedQuery, GameSessionsDto>
{
    public async Task<Result<GameSessionsDto>> Handle(GetGameSessionSortedQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var gameSessions = await gameRepository
                .GetGameSessionsSortedByStatusAndTime(request.Offset, request.Count);

            var gameSessionsDtos = gameSessions.Select(gs =>
                new GameSessionDto(gs.CreatorUsername, gs.Status, gs.Id,
                    gs.MaxAllowedRating, gs.DateTimeCreated)
                ).ToList();
            var allGamesDto = new GameSessionsDto(gameSessionsDtos);

            return new Result<GameSessionsDto>(allGamesDto, true);
        }
        catch (Exception ex)
        {
            return new Result<GameSessionsDto>(null, false, ex.Message);
        }
    }
}
