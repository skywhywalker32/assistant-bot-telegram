using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface INotesRepository
{
    Task<List<Note>> GetAllByUserIdAsync(int userId);

    Task<Note?> GetByIdAsync(int id);

    Task AddAsync(Note note);

    Task UpdateAsync(Note note);
    
    Task DeleteByIdAsync(int id);
}