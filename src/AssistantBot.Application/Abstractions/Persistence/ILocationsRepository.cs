using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface ILocationsRepository
{
    Task AddAsync(Location location);
    
    Task UpdateAsync(Location location);
}