using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Common.UI;
using AssistantBot.Domain.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = AssistantBot.Domain.Entities.User;

namespace AssistantBot.Infrastructure.Telegram.Handlers;

public class NoteMenuHandler : IMenuHandler
{
    private readonly IUsersWriteService _usersWriteService;
    private readonly ITelegramBotService _botService;

    public NoteMenuHandler(IUsersWriteService usersWriteService, ITelegramBotService botService)
    {
        _usersWriteService = usersWriteService;
        _botService = botService;
    }
    
    public MenuState State { get; } = MenuState.NoteMenu;

    public async Task HandleAsync(Update update, User user)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
            {
                if (update.Message is { } message)
                {
                    await HandleMessageAsync(message, user);
                }

                break;
            }
            case UpdateType.CallbackQuery:
            {
                if (update.CallbackQuery is { } query)
                {
                    await HandleCallbackAsync(query, user);
                }

                break;
            }
        }
    }

    private async Task HandleMessageAsync(Message message, User user)
    {
        if (user.ActionState == ActionState.None)
        {
        }
    }

    private async Task HandleCallbackAsync(CallbackQuery query, User user)
    {
        if (user.ActionState == ActionState.None)
        {
            switch (query.Data)
            {
                case BotCallbacks.NoteMenu.Back:
                {
                    var msgId = await _botService.EditOrSendToMainMenuAsync(user.ChatId, user.MessageId);

                    await _usersWriteService.ChangeMessageIdAsync(user, msgId);
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.MainMenu);

                    break;
                }
            }
        }
    }
}