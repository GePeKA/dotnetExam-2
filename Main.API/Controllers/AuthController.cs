using Main.API.Models;
using Main.Features.Auth.Commands.RegisterUser;
using Main.Features.Auth.Queries.AuthenticateUser;
using Mediator.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Main.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController (IMediator mediator): ControllerBase
    {
        [HttpPost("signup")]
        public async Task<IActionResult> RegisterUser(AuthUserRequest registerRequest)
        {
            var result = await mediator.Send(
                new RegisterUserCommand(registerRequest.UserName, registerRequest.Password));

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> AuthenticateUser(AuthUserRequest authRequest)
        {
            var result = await mediator.Send(
                new AuthUserQuery(authRequest.UserName, authRequest.Password));

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}
