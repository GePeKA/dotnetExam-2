namespace Domain.Entities
{
    public class Round
    {
        public Guid Id { get; set; }

        public int RoundNumber { get; set; }

        public string PlayerXUsername { get; set; } = null!;
        public User PlayerX { get; set; } = null!;

        public string PlayerOUsername { get; set; } = null!; 
        public User PlayerO { get; set; } = null!;

        //Для того, чтобы не искать все ходы, здесь после каждого хода делаем +1
        public short CurrentMove { get; set; }

        public List<Move> Moves { get; set; } = [];
    }
}
