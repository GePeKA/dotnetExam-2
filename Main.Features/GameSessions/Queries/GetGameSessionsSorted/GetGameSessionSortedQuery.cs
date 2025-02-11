using Shared.CQRS.Queries;

namespace Main.Features.GameSessions.Queries.GetGameSessionsSorted
{
    public class GetGameSessionSortedQuery(int offset, int count): IQuery<GameSessionsDto>
    {
        public int Offset { get; set; } = offset;
        public int Count { get; set; } = count;
    }
}
