using AssistantBot.Application.DTOs;

namespace AssistantBot.Application.Abstractions.InternalServices;

public interface INotesWriteService
{
    Task AddNoteAsync(AddNoteDto dto);
    Task UpdateNoteAsync(UpdateNoteDto dto);
    Task DeleteNoteAsync(DeleteNoteDto dto);
}