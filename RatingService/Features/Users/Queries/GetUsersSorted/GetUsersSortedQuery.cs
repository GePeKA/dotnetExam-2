using Shared.CQRS.Queries;

namespace RatingService.Features.Users.Queries.GetUsersSorted
{
    public class GetUsersSortedQuery(int offset, int count): IQuery<GetUsersSortedDto>
    {
        public int Offset { get; set; } = offset;
        public int Count { get; set; } = count;
    }
}
