using MassTransit;
using Mediator.Mediator;
using RatingService.Features.Users.Commands.CreateUser;
using Shared.MessagingContracts;

namespace RatingService.Consumers
{
    public class UserConsumer(
        IMediator mediator,
        ILogger<UserConsumer> logger) : IConsumer<UserCreatedEvent>
    {
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var createUserCommand = new CreateUserCommand(context.Message.UserName);
            var result = await mediator.Send(createUserCommand);

            if (result.IsFailure)
            {
                logger.LogError("Error occured while creating user {UserName}: {InternalMessage}",
                    context.Message.UserName,
                    result.Error);
            }
        }
    }
}
