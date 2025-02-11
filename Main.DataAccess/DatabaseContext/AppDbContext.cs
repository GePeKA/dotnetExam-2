using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Main.DataAccess.DatabaseContext
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<GameSession> GameSessions => Set<GameSession>();
        public DbSet<Round> Rounds => Set<Round>();
        public DbSet<Move> Moves => Set<Move>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserName);
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            //GameSession
            modelBuilder.Entity<GameSession>()
                .HasKey(gs => gs.Id);
            modelBuilder.Entity<GameSession>()
                .Property(gs => gs.Status)
                .HasConversion<short>();
            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.CreatorUser)
                .WithMany(u => u.CreatedGameSessions)
                .HasForeignKey(gs => gs.CreatorUsername);
            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.Opponent)
                .WithMany(u => u.JoinedGameSessions)
                .HasForeignKey(gs => gs.OpponentUsername);
            modelBuilder.Entity<GameSession>()
                .HasMany(gs => gs.Rounds)
                .WithOne(r => r.GameSession)
                .HasForeignKey(r => r.GameSessionId);

            //Round
            modelBuilder.Entity<Round>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Round>()
                .HasOne(r => r.PlayerX)
                .WithMany()
                .HasForeignKey(r => r.PlayerXUsername);
            modelBuilder.Entity<Round>()
                .HasOne(r => r.PlayerO)
                .WithMany()
                .HasForeignKey(r => r.PlayerOUsername);
            modelBuilder.Entity<Round>()
                .HasOne(r => r.Winner)
                .WithMany()
                .HasForeignKey(r => r.WinnerUsername);
            modelBuilder.Entity<Round>()
                .HasMany(r => r.Moves)
                .WithOne(m => m.Round)
                .HasForeignKey(m => m.RoundId);

            //Move
            modelBuilder.Entity<Move>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<Move>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.Username);


            base.OnModelCreating(modelBuilder);
        }
    }
}
