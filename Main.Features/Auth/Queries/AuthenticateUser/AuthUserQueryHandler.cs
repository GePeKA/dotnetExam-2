using Domain.Abstractions.Repositories;
using Main.Infrastructure.Services.Abstractions;
using Shared.CQRS.Queries;
using Shared.DTO;

namespace Main.Features.Auth.Queries.AuthenticateUser
{
    public class AuthUserQueryHandler(
        ITokenService tokenService,
        IHasherService hasherService,
        IUserRepository userRepository
        ): IQueryHandler<AuthUserQuery, AuthUserDto>
    {
        public async Task<Result<AuthUserDto>> Handle(AuthUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserAsync(request.UserName);

            if (user == null)
            {
                return new Result<AuthUserDto>(null, false, "No user found with such username!");
            }

            if (!hasherService.Verify(request.Password, user.Password))
            {
                return new Result<AuthUserDto>(null, false, "Wrong password!");
            }

            var jwtToken = tokenService.GenerateJwtAccessToken(user);

            return new Result<AuthUserDto>(new AuthUserDto(jwtToken), true);
        }
    }
}
