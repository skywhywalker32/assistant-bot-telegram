using AssistantBot.Application.DTOs;

namespace AssistantBot.Application.Abstractions.InternalServices;

public interface ILocationsWriteService
{
    Task AddLocationAsync(LocationDto dto);
}