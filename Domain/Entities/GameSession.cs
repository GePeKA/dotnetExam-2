namespace Domain.Entities
{
    public class GameSession
    {
        public long Id { get; set; }

        public GameSessionStatus Status { get; set; }

        public DateTimeOffset DateTimeCreated { get; set; } = DateTimeOffset.UtcNow;

        public int MaxAllowedRating { get; set; }

        public string CreatorUsername { get; set; } = null!;
        public User CreatorUser { get; set; } = null!;

        public string OpponentUsername { get; set; } = null!;
        public User Opponent { get; set; } = null!;

        //Для того, чтобы не искать все раунды. Здесь после каждого раунда делаем +1
        public int CurrentRound { get; set; }

        public List<Round> Rounds { get; set; } = [];
    }

    public enum GameSessionStatus
    {
        Open,
        InProgress,
        Closed
    }
}
