using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface INotesRepository
{
    Task<List<Note>> GetAllFromUserByIdAsync(int id);
    Task<Note> GetByIdAsync(int id);
}