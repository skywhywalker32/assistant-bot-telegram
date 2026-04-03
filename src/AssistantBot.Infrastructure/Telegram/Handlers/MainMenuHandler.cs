using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = AssistantBot.Domain.Entities.User;
using AssistantBot.Application.Common.UI;
using AssistantBot.Domain.Enums;

namespace AssistantBot.Infrastructure.Telegram.Handlers;

public class MainMenuHandler : IMenuHandler
{
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
        if (message.Text == BotButtons.MainMenu.Note && user.ActionState == ActionState.None)
        {
            // 1. изменить состояние MenuState юзера на NoteMenu через usersWriteService
            
            // 2. отрисовать NoteMenu через services/TelegramBotService юзеру
        }
    }

    private async Task HandleCallbackAsync(CallbackQuery query, User user)
    {
        
    }
}