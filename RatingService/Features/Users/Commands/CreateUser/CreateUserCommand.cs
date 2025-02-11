using Shared.CQRS.Commands;

namespace RatingService.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand(string userName): ICommand
    {
        public string UserName { get; set; } = userName;
    }
}
