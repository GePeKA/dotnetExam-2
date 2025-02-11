using Domain.Entities;

namespace Main.Infrastructure.Services.Abstractions
{
    public interface ITokenService
    {
        string GenerateJwtAccessToken(User user);
    }
}
