using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Abstractions.Persistence;

public interface IUsersRepository
{
    Task AddAsync(User user);
    
    Task<User?> GetByIdAsync(int id);
    
    Task<User?> GetByChatIdAsync(long chatId);
}