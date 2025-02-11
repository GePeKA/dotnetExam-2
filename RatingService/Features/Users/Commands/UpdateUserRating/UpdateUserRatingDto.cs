namespace RatingService.Features.Users.Commands.UpdateUserRating
{
    public record UpdateUserRatingDto(string UserName, int CurrentRating);
}
