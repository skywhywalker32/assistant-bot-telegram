using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Application.DTOs;
using AssistantBot.Domain.Entities;

namespace AssistantBot.Application.Services.Writes;

public class LocationsWriteService : ILocationsWriteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILocationsRepository _locationsRepository;
    private readonly IUsersRepository _usersRepository;

    public LocationsWriteService(IUnitOfWork unitOfWork, ILocationsRepository locationsRepository, IUsersRepository usersRepository)
    {
        _unitOfWork = unitOfWork;
        _locationsRepository = locationsRepository;
        _usersRepository = usersRepository;
    }
    
    public async Task AddLocationAsync(LocationDto dto)
    {
        var user = await _usersRepository.GetByChatIdAsync(dto.ChatId);

        if (user is null)
        {
            return;
        }

        var locationEntity = Location.Create(dto.Longitude, dto.Latitude, user.Id);

        await _locationsRepository.AddAsync(locationEntity);

        await _unitOfWork.CommitChangesAsync();
    }
}