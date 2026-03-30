using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Application.DTOs;
using AssistantBot.Domain.Entities;
using AssistantBot.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace AssistantBot.Application.Services.Writes;

public class LocationsWriteService : ILocationsWriteService
{
    private readonly ILogger<LocationsWriteService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILocationsRepository _locationsRepository;
    private readonly IUsersRepository _usersRepository;

    public LocationsWriteService(
        ILogger<LocationsWriteService> logger,
        IUnitOfWork unitOfWork,
        ILocationsRepository locationsRepository,
        IUsersRepository usersRepository)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _locationsRepository = locationsRepository;
        _usersRepository = usersRepository;
    }
    
    public async Task UpsertLocationAsync(UpsertLocationDto upsertLocationDto)
    {
        var user = await _usersRepository.GetByChatIdAsync(upsertLocationDto.ChatId);

        if (user is null)
        {
            throw new Exception("Unknown user");
        }

        try
        {
            if (user.Location is null)
            {
                var locationEntity = Location.Create(upsertLocationDto.Longitude, upsertLocationDto.Latitude, user.Id);

                await _locationsRepository.AddAsync(locationEntity);
            }
            else
            {
                user.Location.UpdateCoords(upsertLocationDto.Longitude, upsertLocationDto.Latitude);
            }
        }
        catch (LocationException e)
        {
            _logger.LogError(e, "User with chatId:{ChatId} has send wrong location data", user.ChatId);
            throw;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "General exeption in UpsertLocationAsync");
            throw;
        }
        
        await _unitOfWork.CommitChangesAsync();
    }
}