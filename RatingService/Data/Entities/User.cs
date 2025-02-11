using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RatingService.Data.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string UserName { get; set; } = null!;

    [BsonRepresentation(BsonType.Int32)]
    public int Rating { get; set; } = 0;
}
