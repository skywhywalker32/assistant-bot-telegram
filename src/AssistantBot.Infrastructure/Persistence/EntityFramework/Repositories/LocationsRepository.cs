using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;

public class LocationsRepository : ILocationsRepository
{
    public async Task<Location> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateByIdAsync(int id, Location location)
    {
        throw new NotImplementedException();
    }
}