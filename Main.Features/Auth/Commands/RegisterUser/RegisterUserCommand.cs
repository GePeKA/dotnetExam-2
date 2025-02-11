using Shared.CQRS.Commands;

namespace Main.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand(string userName, string password): ICommand<RegisterUserDto>
    {
        public string UserName { get; set; } = userName;
        public string Password { get; set; } = password;
    }
}
