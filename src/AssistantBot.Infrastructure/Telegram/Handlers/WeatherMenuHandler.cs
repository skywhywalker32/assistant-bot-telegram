using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Common.UI;
using AssistantBot.Domain.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = AssistantBot.Domain.Entities.User;

namespace AssistantBot.Infrastructure.Telegram.Handlers;

public class WeatherMenuHandler : IMenuHandler
{
    private readonly IUsersWriteService _usersWriteService;
    private readonly ITelegramBotService _botService;

    public WeatherMenuHandler(IUsersWriteService usersWriteService, ITelegramBotService botService)
    {
        _usersWriteService = usersWriteService;
        _botService = botService;
    }
    public MenuState State { get; } = MenuState.WeatherMenu;

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
                case BotCallbacks.WeatherMenu.Back:
                {
                    var msgId = await _botService.EditOrSendToMainMenuAsync(user.ChatId, 1);

                    await _usersWriteService.ChangeMessageIdAsync(user, msgId);
                    await _usersWriteService.ChangeMenuStateAsync(user, MenuState.MainMenu);

                    break;
                }
            }
        }
    }
}