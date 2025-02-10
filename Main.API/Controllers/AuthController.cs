using Mediator.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Main.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController (IMediator mediator): ControllerBase
    {

    }
}
