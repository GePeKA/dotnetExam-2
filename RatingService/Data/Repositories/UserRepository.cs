using MongoDB.Driver;
using RatingService.Data.DatabaseContext;
using RatingService.Data.Entities;

namespace RatingService.Data.Repositories
{
    public class UserRepository(MongoDbContext mongoDb) : IUserRepository
    {
        public async Task AddUserAsync(User user)
        {
            await mongoDb.Users.InsertOneAsync(user);
        }

        public async Task<User?> ChangeUserRatingAsync(string userName, int ratingChange)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserName, userName);
            var update = Builders<User>.Update.Inc(u => u.Rating, ratingChange);

            var options = new FindOneAndUpdateOptions<User>
            {
                ReturnDocument = ReturnDocument.After // Возвращаем документ после обновления
            };

            var result = await mongoDb.Users.FindOneAndUpdateAsync(filter, update, options);
            return result;
        }

        public async Task<List<User>> GetUsersSortedByRatingAsync(int count, int offset)
        {
            var filter = Builders<User>.Filter.Empty;
            var sort = Builders<User>.Sort.Descending(u => u.Rating);

            var result = await mongoDb.Users.Find(filter)
                .Sort(sort)
                .Skip(offset)
                .Limit(count)
                .ToListAsync();

            return result;
        }
    }
}
