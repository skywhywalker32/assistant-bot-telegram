using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface ILocationsRepository
{
    Task UpdateAsync(Location location);
}