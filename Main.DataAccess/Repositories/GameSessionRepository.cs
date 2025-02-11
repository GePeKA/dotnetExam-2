using Domain.Abstractions.Repositories;
using Domain.Entities;
using Main.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Main.DataAccess.Repositories
{
    public class GameSessionRepository(AppDbContext dbContext) : IGameSessionRepository
    {
        public async Task<long> AddGameSessionAsync(GameSession gameSession)
        {
            var entityEntry = await dbContext.GameSessions.AddAsync(gameSession);

            return entityEntry.Entity.Id;
        }

        public async Task<GameSession?> GetGameSessionAsync(long gameSessionId)
        {
            var gameSession = await dbContext.GameSessions
                .Include(gs => gs.Rounds)
                .ThenInclude(r => r.Moves)
                .FirstOrDefaultAsync(gs => gs.Id == gameSessionId);

            return gameSession;
        }

        public async Task<List<GameSession>> GetGameSessionsSortedByStatusAndTime(int offset, int count)
        {
            var gameSessions = await dbContext.GameSessions
                .AsNoTracking()
                .OrderBy(gs => gs.Status)
                .ThenByDescending(gs => gs.DateTimeCreated)
                .Skip(offset)
                .Take(count)
                .ToListAsync();

            return gameSessions;
        }
    }
}
