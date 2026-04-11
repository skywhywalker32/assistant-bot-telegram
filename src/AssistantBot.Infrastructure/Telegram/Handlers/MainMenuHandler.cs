using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Abstractions.InternalServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = AssistantBot.Domain.Entities.User;
using AssistantBot.Application.Common.UI;
using AssistantBot.Domain.Enums;

namespace AssistantBot.Infrastructure.Telegram.Handlers;

public class MainMenuHandler : IMenuHandler
{
    private readonly IUsersWriteService _usersWriteService;
    private readonly ITelegramBotService _botService;

    public MainMenuHandler(IUsersWriteService usersWriteService, ITelegramBotService botService)
    {
        _usersWriteService = usersWriteService;
        _botService = botService;
    }
    
    public MenuState State { get; } = MenuState.MainMenu;

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
            if (message.Text == BotCommands.Start)
            {
                var msgId = await _botService.SendWelcomeMessageAsync(user.ChatId);

                await _usersWriteService.ChangeMessageIdAsync(user, msgId);
                await _usersWriteService.ChangeMenuStateAsync(user, MenuState.MainMenu);
            }
        }
    }

    private async Task HandleCallbackAsync(CallbackQuery query, User user)
    {
        if (user.ActionState == ActionState.None)
        {
            switch (query.Data)
            {
                case BotCallbacks.MainMenu.NoteMenuCallback:
                {
                    var msgId = await _botService.EditOrSendToNoteMenuAsync(user.ChatId, user.MessageId);
                    
                    await _usersWriteService.ChangeMessageIdAsync(user, msgId);
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.NoteMenu);
                    
                    break;
                }

                case BotCallbacks.MainMenu.WeatherMenuCallback:
                {
                    var msgId = await _botService.EditOrSendToWeatherMenuAsync(user.ChatId, user.MessageId);
                    
                    await _usersWriteService.ChangeMessageIdAsync(user, msgId);
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.WeatherMenu);
                    
                    break;
                }
                
                case BotCallbacks.MainMenu.AIChatCallback:
                {
                    var msgId = await _botService.EditOrSendToAiChatAsync(user.ChatId, user.MessageId);

                    await _usersWriteService.ChangeMessageIdAsync(user, msgId);
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.AiChat);
                    
                    break;
                }
            }
        }
    }
}