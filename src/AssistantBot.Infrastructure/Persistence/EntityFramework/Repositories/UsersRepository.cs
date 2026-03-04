using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public UsersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
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