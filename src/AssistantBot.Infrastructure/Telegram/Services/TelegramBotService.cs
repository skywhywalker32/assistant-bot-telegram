using AssistantBot.Application.Abstractions.ExternalServices;

namespace AssistantBot.Infrastructure.Telegram.Services;

public class TelegramBotService : ITelegramBotService
{
    public async Task HandleMessage()
    {
        throw new NotImplementedException();
    }

    public async Task HandleCallbackQuery()
    {
        throw new NotImplementedException();
    }
}