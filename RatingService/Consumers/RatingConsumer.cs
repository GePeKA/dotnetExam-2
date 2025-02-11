using MassTransit;
using Mediator.Mediator;
using RatingService.Features.Users.Commands.UpdateUserRating;
using Shared.MessagingContracts;

namespace RatingService.Consumers
{
    public class RatingConsumer(
        ILogger<RatingConsumer> logger,
        IMediator mediator) : IConsumer<RatingChangedEvent>
    {
        public async Task Consume(ConsumeContext<RatingChangedEvent> context)
        {
            var updateRatingCommand = new UpdateUserRatingCommand(
                context.Message.UserName,
                context.Message.RatingChange);

            var result = await mediator.Send(updateRatingCommand);
            if (result.IsFailure)
            {
                logger.LogError("Error occurred while updating the rating of user {UserName} and changing the rating by {RatingChange}: {InternalMessage}",
                    context.Message.UserName,
                    context.Message.RatingChange,
                    result.Error);
            }
        }
    }
}
