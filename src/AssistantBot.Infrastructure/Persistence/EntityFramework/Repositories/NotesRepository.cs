using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NotesRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Note>> GetAllByUserIdAsync(int userId)
    {
        return await _dbContext.Notes
            .AsNoTracking()
            .Where(n => n.UserId == userId)
            .ToListAsync();
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        return await _dbContext.Notes
            .FirstOrDefaultAsync(n => n.Id == id);
    }
    
    public Task AddAsync(Note note)
    {
        _dbContext.Notes.Add(note);

        return Task.CompletedTask;
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