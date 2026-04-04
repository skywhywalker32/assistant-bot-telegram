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
            if (message.Text == BotButtons.MainMenu.Note)
            {
                // 1. изменить состояние MenuState юзера на NoteMenu через usersWriteService
                await _usersWriteService.ChangeMenuStateAsync(user, MenuState.NoteMenu);

                // 2. отрисовать NoteMenu через services/TelegramBotService юзеру
            }
            else if (message.Text == BotButtons.MainMenu.Weather)
            {
                  
            }

            if (message.Text == BotButtons.MainMenu.AIChat)
            {
                
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
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.NoteMenu);
                    await _botService.EditToNoteMenuAsync(user.ChatId, 2);
                    break;
                }

                case BotCallbacks.MainMenu.WeatherMenuCallback:
                {
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.WeatherMenu);
                    await _botService.EditToWeatherMenuAsync(user.ChatId, 2);
                    break;
                }
                
                case BotCallbacks.MainMenu.AIChatCallback:
                {
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.AiChat);
                    await _botService.EditToAiChatAsync(user.ChatId, 2);
                    break;
                }
            }
        }
    }
}