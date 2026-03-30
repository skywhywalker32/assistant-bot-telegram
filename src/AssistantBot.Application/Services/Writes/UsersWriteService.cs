using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Application.DTOs;
using AssistantBot.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace AssistantBot.Application.Services.Writes;

public class UsersWriteService : IUsersWriteService
{
    private readonly ILogger<UsersWriteService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepository _usersRepository;

    public UsersWriteService(
        ILogger<UsersWriteService> logger,
        IUnitOfWork unitOfWork,
        IUsersRepository usersRepository)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _usersRepository = usersRepository;
    }
    
    public async Task UpsertUserAsync(UpsertUserDto upsertUserDto)
    {
        var user = await _usersRepository.GetByChatIdAsync(upsertUserDto.ChatId);
        
        if (user is null)
        {
            var newUserEntity = User.Create(upsertUserDto.ChatId, upsertUserDto.Username);
            
            _logger.LogInformation("Новый пользователь с ником {username} зарегестрирован", upsertUserDto.Username);
            
            _usersRepository.Add(newUserEntity);
        }
        else
        {
            user.UpdateUsername(upsertUserDto.Username);
        }

        await _unitOfWork.CommitChangesAsync();
    }
}