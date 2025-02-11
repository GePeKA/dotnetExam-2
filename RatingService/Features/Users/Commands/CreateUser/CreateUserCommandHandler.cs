using RatingService.Data.Entities;
using RatingService.Data.Repositories;
using Shared.CQRS.Commands;
using Shared.DTO;

namespace RatingService.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand>
    {
        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new User()
                {
                    UserName = request.UserName,
                    Rating = 0
                };
                await userRepository.AddUserAsync(newUser);

                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
