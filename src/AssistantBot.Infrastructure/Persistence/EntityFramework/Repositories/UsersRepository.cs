using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using User = AssistantBot.Domain.Entities.User;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public UsersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(User user)
    {
        _dbContext.Users.Add(user);
    }
        
    public async Task<User?> GetByIdAsync(int id)
    {   
        return await _dbContext.Users
            .Include(u => u.Location)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByChatIdAsync(long chatId)
    {
        return await _dbContext.Users
            .Include(u => u.Location)
            .FirstOrDefaultAsync(u => u.ChatId == chatId);
    }
}