using AssistantBot.Application.DTOs;

namespace AssistantBot.Application.Abstractions.InternalServices;

public interface IUsersWriteService
{
    Task UpsertUserAsync(UpsertUserDto dto);
}