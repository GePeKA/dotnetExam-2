using Shared.CQRS.Commands;

namespace RatingService.Features.Users.Commands.UpdateUserRating
{
    public class UpdateUserRatingCommand(string userName, int ratingChange): ICommand<UpdateUserRatingDto>
    {
        public string UserName { get; set; } = userName;
        public int RatingChange { get; set; } = ratingChange;
    }
}
