namespace Domain.Entities
{
    public class User
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public List<GameSession>? CreatedGameSessions { get; set; }
        public List<GameSession>? JoinedGameSessions { get; set; }
    }
}
