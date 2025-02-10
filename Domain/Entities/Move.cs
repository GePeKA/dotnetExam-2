namespace Domain.Entities
{
    public class Move
    {
        public Guid Id { get; set; }
        
        public short MoveNumber { get; set; }

        public short CellIndex { get; set; }

        public string Username { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
