using RatingService.Configurations;
using RatingService.Data.MongoDbContext;

namespace RatingService.ServicesExtensions.Mongo
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, MongoDbConfig mongoConfig)
        {
            var mongoDbContext = new MongoDbContext(
                mongoConfig.MongoDbConnectionString,
                mongoConfig.MongoDbName
            );

            return services
                .AddSingleton(mongoDbContext);
        }
    }
}
