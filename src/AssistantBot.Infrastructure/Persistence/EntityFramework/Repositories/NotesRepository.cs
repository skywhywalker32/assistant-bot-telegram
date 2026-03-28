using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NotesRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task UpdateAsync(Note note)
    {
        _dbContext.Notes.Update(note);

        return Task.CompletedTask;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var note = await _dbContext.Notes.FindAsync(id);

        if (note != null)
        {
            _dbContext.Notes.Remove(note);
        }
    }
}