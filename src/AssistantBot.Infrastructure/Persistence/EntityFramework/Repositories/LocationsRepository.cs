using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LocationsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task AddAsync(Location location)
    {
        _dbContext.Locations.Add(location);

        return Task.CompletedTask;
    }
    
    public Task UpdateAsync(Location location)
    {
        _dbContext.Locations.Update(location);
        
        return Task.CompletedTask;
    }
}