using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;

public class NotesRepository : INotesRepository
{
    public async Task<List<Note>> GetAllFromUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Note> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}