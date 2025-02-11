using Domain.Abstractions.Repositories;
using Domain.Entities;
using Main.DataAccess.DatabaseContext;

namespace Main.DataAccess.Repositories
{
    public class GameSessionRepository(AppDbContext dbContext) : IGameSessionRepository
    {
        public async Task<long> AddGameSessionAsync(GameSession gameSession)
        {
            var entityEntry = await dbContext.GameSessions.AddAsync(gameSession);

            return entityEntry.Entity.Id;
        }
    }
}
