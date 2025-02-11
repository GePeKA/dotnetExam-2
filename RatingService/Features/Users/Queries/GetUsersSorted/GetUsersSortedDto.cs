using RatingService.Data.Entities;

namespace RatingService.Features.Users.Queries.GetUsersSorted;

public record GetUsersSortedDto(List<User> Users);