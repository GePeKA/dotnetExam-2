using Mediator.Mediator;
using Microsoft.AspNetCore.Mvc;
using RatingService.Features.Users.Queries.GetUsersSorted;

namespace RatingService.Controllers
{
    [Route("rating-api")]
    [ApiController]
    public class RatingController(IMediator mediator) : ControllerBase
    {
        [HttpGet("users")]
        public async Task<IActionResult> GetUserSortedByRatings(int offset, int count)
        {
            var result = await mediator.Send(new GetUsersSortedQuery(offset, count));

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}
