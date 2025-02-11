using RatingService.Data.Repositories;
using Shared.CQRS.Queries;
using Shared.DTO;

namespace RatingService.Features.Users.Queries.GetUsersSorted
{
    public class GetUsersSortedQueryHandler(
        IUserRepository userRepository) : IQueryHandler<GetUsersSortedQuery, GetUsersSortedDto>
    {
        public async Task<Result<GetUsersSortedDto>> Handle(GetUsersSortedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await userRepository.GetUsersSortedByRatingAsync(request.Count, request.Offset);
                var usersDto = new GetUsersSortedDto(users);

                return new Result<GetUsersSortedDto>(usersDto, true);
            }
            catch (Exception ex)
            {
                return new Result<GetUsersSortedDto>(null, false, ex.Message);
            }
        }
    }
}
