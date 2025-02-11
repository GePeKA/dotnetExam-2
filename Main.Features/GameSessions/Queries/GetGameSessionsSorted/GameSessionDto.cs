using Domain.Entities;

namespace Main.Features.GameSessions.Queries.GetGameSessionsSorted;

public record GameSessionDto(string CreatorUserName, GameSessionStatus Status,
    long Id, int MaxAllowedRating, DateTimeOffset DateTimeCreated);
