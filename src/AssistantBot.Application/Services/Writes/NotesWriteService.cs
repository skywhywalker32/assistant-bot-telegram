using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Application.DTOs;
using AssistantBot.Domain.Entities;
using AssistantBot.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace AssistantBot.Application.Services.Writes;

public class NotesWriteService : INotesWriteService
{
    private readonly ILogger<NotesWriteService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepository _usersRepository;
    private readonly INotesRepository _notesRepository;

    public NotesWriteService(
        ILogger<NotesWriteService> logger,
        IUnitOfWork unitOfWork,
        IUsersRepository usersRepository,
        INotesRepository notesRepository)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _usersRepository = usersRepository;
        _notesRepository = notesRepository;
    }

    public async Task AddNoteAsync(AddNoteDto addNoteDto)
    {
        var user = await _usersRepository.GetByChatIdAsync(addNoteDto.ChatId);

        if (user is null)
        {
            throw new Exception("Unknown user");
        }

        try
        {
            var newNoteEntity = Note.Create(addNoteDto.Title, addNoteDto.Text, user.Id);
            
            _notesRepository.Add(newNoteEntity);
        }
        catch (NoteException e)
        {
            _logger.LogError(e, "Пользователь с chatId:{chatId} отправил неправильные данные заметки", user.ChatId);
            throw;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Общая ошибка в AddNoteAsync");
            throw;
        }

        await _unitOfWork.CommitChangesAsync();
    }

    public async Task UpdateNoteAsync(UpdateNoteDto updateNoteDto)
    {
        var user = await _usersRepository.GetByChatIdAsync(updateNoteDto.ChatId);

        if (user is null)
        {
            throw new Exception("Unknown user");
        }

        try
        {
            var noteToModify = await _notesRepository.GetByIdAsync(updateNoteDto.Id);

            if (noteToModify is null)
            {
                throw new Exception("Note to modify is null");
            }

            noteToModify.UpdateNote(updateNoteDto.Title, updateNoteDto.Text);
        }
        catch (NoteException e)
        {
            _logger.LogError(e, "Пользователь с chatId:{chatId} отправил неправильные данные заметки", user.ChatId);
            throw;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Общая ошибка в UpdateNoteAsync");
            throw;
        }

        await _unitOfWork.CommitChangesAsync();
    }

    public async Task DeleteNoteAsync(DeleteNoteDto deleteNoteDto)
    {
        try
        {
            var isDeleted = await _notesRepository.DeleteByIdAsync(deleteNoteDto.Id);

            if (isDeleted == false)
            {
                throw new Exception($"Попытка удалить несуществующую заметку с id:{deleteNoteDto.Id}");
            }
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Попытка удалить несуществующую заметку с id:{id}", deleteNoteDto.Id);
            throw;
        }
        
        await _unitOfWork.CommitChangesAsync();
    }
}