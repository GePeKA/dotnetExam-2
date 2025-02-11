using Domain.Abstractions.Repositories;
using Domain.Entities;
using Main.Infrastructure.Services.Abstractions;
using Main.Infrastructure.UnitOfWork;
using Shared.CQRS.Commands;
using Shared.DTO;

namespace Main.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IHasherService hasherService) : ICommandHandler<RegisterUserCommand, RegisterUserDto>
    {
        public async Task<Result<RegisterUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) 
                || string.IsNullOrWhiteSpace(request.Password))
            {
                return new Result<RegisterUserDto>(null, false, "Username and password must not be empty!");
            }

            var isUserWithUsernameExist = (await userRepository.GetUserAsync(request.UserName)) != null;

            if (isUserWithUsernameExist)
            {
                return new Result<RegisterUserDto>(null, false, "User with such username already exists!");
            }

            var hashedPassword = hasherService.Hash(request.Password);

            var user = new User()
            {
                UserName = request.UserName,
                Password = hashedPassword
            };

            var createdUsername = await userRepository.AddUserAsync(user);
            await unitOfWork.SaveChangesAsync();

            return new Result<RegisterUserDto>(new RegisterUserDto(createdUsername), true);
        }
    }
}
