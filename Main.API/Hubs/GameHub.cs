using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Main.API.Hubs
{
    [Authorize]
    public class GameHub: Hub
    {

    }
}
