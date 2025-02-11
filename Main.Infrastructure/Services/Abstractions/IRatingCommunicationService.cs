using Shared.MessagingContracts;

namespace Main.Infrastructure.Services.Abstractions
{
    public interface IRatingCommunicationService
    {
        Task SendRatingChangedEvent(RatingChangedEvent ratingChangedEvent);
        Task SendUserCreatedEvent(UserCreatedEvent userCreatedEvent);
    }
}
