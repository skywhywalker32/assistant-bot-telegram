using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface ILocationsRepository
{
    void Add(Location location);
}