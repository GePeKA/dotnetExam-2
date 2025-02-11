using Main.API.Models;
using Main.Features.GameSessions.Commands.CreateGameSession;
using Main.Features.GameSessions.Queries.GetGameSessionsSorted;
using Mediator.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main.API.Controllers
{
    [Route("api/game-sessions")]
    [Authorize]
    [ApiController]
    public class GameSessionController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGameSessionsSortedByStatusAndTime(int offset, int count)
        {
            var result = await mediator.Send(new GetGameSessionSortedQuery(offset, count));

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameSession(CreateGameSessionRequest request)
        {
            var userName = User.Identity!.Name!;
            var result = await mediator.Send(new CreateGameSessionCommand(userName, request.MaxAllowedRating));

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}
