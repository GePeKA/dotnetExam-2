using Main.Infrastructure.Services.Abstractions;
using MassTransit;
using Shared.MessagingContracts;

namespace Main.Infrastructure.Services.Implementations
{
    public class RatingCommunicationService(IBus bus) : IRatingCommunicationService
    {
        public async Task SendRatingChangedEvent(RatingChangedEvent ratingChangedEvent)
        {
            await bus.Publish(ratingChangedEvent);
        }

        public async Task SendUserCreatedEvent(UserCreatedEvent userCreatedEvent)
        {
            await bus.Publish(userCreatedEvent);
        }
    }
}
