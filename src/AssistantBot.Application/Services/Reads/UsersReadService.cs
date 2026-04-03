using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Services.Reads;

public class UsersReadService : IUsersReadService
{
    private readonly IUsersRepository _usersRepository;

    public UsersReadService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<User?> GetByChatIdAsync(long chatId)
    {
        return await _usersRepository.GetByChatIdAsync(chatId);
    }
}