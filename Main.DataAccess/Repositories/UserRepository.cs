using Domain.Abstractions.Repositories;
using Domain.Entities;
using Main.DataAccess.DatabaseContext;

namespace Main.DataAccess.Repositories
{
    public class UserRepository (AppDbContext dbContext) : IUserRepository
    {
        public async Task<string> AddUserAsync(User user)
        {
            var entityEntry = await dbContext.Users.AddAsync(user);

            return entityEntry.Entity.UserName;
        }

        public async Task<User?> GetUserAsync(string userName)
        {
            var user = await dbContext.Users.FindAsync(userName);

            return user;
        }
    }
}
