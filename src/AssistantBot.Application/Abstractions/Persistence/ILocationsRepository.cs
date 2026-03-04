using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface ILocationsRepository
{
    Task<Location> GetByIdAsync(int id);
    Task UpdateByIdAsync(int id, Location location);
}