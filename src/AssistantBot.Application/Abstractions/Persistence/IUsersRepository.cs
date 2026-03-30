using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface IUsersRepository
{
    void Add(User user);
    
    Task<User?> GetByIdAsync(int id);
    
    Task<User?> GetByChatIdAsync(long chatId);
}