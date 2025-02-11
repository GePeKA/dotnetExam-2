using RatingService.Data.Entities;

namespace RatingService.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersSortedByRatingAsync(int count, int offset);
        Task AddUserAsync(User user);
        Task<User> ChangeUserRatingAsync(string userName, int ratingChange);
    }
}
