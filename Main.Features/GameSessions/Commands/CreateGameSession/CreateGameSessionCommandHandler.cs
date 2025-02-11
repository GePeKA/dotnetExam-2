using Domain.Abstractions.Repositories;
using Domain.Entities;
using Main.Infrastructure.UnitOfWork;
using Shared.CQRS.Commands;
using Shared.DTO;

namespace Main.Features.GameSessions.Commands.CreateGameSession
{
    public class CreateGameSessionCommandHandler(
        IGameSessionRepository gameRepository,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateGameSessionCommand, CreateGameSessionDto>
    {
        public async Task<Result<CreateGameSessionDto>> Handle(CreateGameSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newGame = new GameSession()
                {
                    CreatorUsername = request.CreatorUserName,
                    MaxAllowedRating = request.MaxAllowedRating,
                    Status = GameSessionStatus.Open
                };
                var createdGameId = await gameRepository.AddGameSessionAsync(newGame);
                await unitOfWork.SaveChangesAsync();

                var createdGameSessionDto = new CreateGameSessionDto(createdGameId);
                return new Result<CreateGameSessionDto>(createdGameSessionDto, true);
            }
            catch (Exception ex)
            {
                return new Result<CreateGameSessionDto>(null, false, ex.Message);
            }
        }
    }
}
