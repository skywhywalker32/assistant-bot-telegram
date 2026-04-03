using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.InternalServices;

public interface IUsersReadService
{
    Task<User?> GetByChatIdAsync(long chatId);
}