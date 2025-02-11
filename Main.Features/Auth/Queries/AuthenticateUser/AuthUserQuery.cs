using Shared.CQRS.Queries;

namespace Main.Features.Auth.Queries.AuthenticateUser
{
    public class AuthUserQuery (string userName, string password): IQuery<AuthUserDto>
    {
        public string UserName { get; set; } = userName;
        public string Password { get; set; } = password;
    }
}
