using Shared.CQRS.Commands;

namespace Main.Features.GameSessions.Commands.CreateGameSession
{
    public class CreateGameSessionCommand(string creatorUsername,
        int maxAllowedRating) : ICommand<CreateGameSessionDto>
    {
        public string CreatorUserName { get; set; } = creatorUsername;
        public int MaxAllowedRating { get; set; } = maxAllowedRating;
    }
}
