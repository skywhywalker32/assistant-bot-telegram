using AssistantBot.Application.DTOs;
using AssistantBot.Domain.Entities;
using AssistantBot.Domain.Enums;

namespace AssistantBot.Application.Abstractions.InternalServices;

public interface IUsersWriteService
{
    Task<User> UpsertUserAsync(UpsertUserDto dto);
    Task ChangeMenuStateAsync(User user, MenuState newMenuState);
}