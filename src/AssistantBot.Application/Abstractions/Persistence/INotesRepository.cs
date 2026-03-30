using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface INotesRepository
{
    Task<List<Note>> GetAllByUserIdAsync(int userId);

    Task<Note?> GetByIdAsync(int id);

    Task AddAsync(Note note);
    
    Task<bool> DeleteByIdAsync(int id);
}