using Domain.Entities;
using Shared.CQRS.Queries;

namespace Main.Features.GameSessions.Queries.GetGameSession
{
    public class GetGameSessionQuery(long id): IQuery<GameSession>
    {
        public long Id { get; set; } = id;
    }
}
