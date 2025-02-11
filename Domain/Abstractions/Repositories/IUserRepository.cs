using Domain.Entities;

namespace Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<string> AddUserAsync(User user);
        Task<User?> GetUserAsync(string userName);
    }
}
