using RatingService.Data.Repositories;
using Shared.CQRS.Commands;
using Shared.DTO;

namespace RatingService.Features.Users.Commands.UpdateUserRating;

public class UpdateUserRatingCommandHandler(
    IUserRepository userRepository) : ICommandHandler<UpdateUserRatingCommand, UpdateUserRatingDto>
{
    public async Task<Result<UpdateUserRatingDto>> Handle(UpdateUserRatingCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var updatedUser = await userRepository.ChangeUserRatingAsync(request.UserName, request.RatingChange);

            return updatedUser == null
                ? new Result<UpdateUserRatingDto>(null, false, "No user found with such UserName")
                : new Result<UpdateUserRatingDto>(
                    new UpdateUserRatingDto(updatedUser.UserName, updatedUser.Rating), true);
        }
        catch (Exception ex)
        {
            return new Result<UpdateUserRatingDto>(null, false, ex.Message);
        }
    }
}
