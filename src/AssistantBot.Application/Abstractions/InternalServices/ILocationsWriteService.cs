using AssistantBot.Application.DTOs;

namespace AssistantBot.Application.Abstractions.InternalServices;

public interface ILocationsWriteService
{
    Task UpsertLocationAsync(UpsertLocationDto dto);
}