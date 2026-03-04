using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface INotesRepository
{
    Task UpdateAsync(Note note);
    Task DeleteByIdAsync(int id);
}