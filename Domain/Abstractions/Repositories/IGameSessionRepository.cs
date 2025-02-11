using Domain.Entities;

namespace Domain.Abstractions.Repositories
{
    public interface IGameSessionRepository
    {
        Task<long> AddGameSessionAsync(GameSession gameSession);
        Task<List<GameSession>> GetGameSessionsSortedByStatusAndTime(int offset, int count);
        Task<GameSession?> GetGameSessionAsync(long gameSessionId);
    }
}
