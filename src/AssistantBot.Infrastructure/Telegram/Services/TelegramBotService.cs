using AssistantBot.Application.Abstractions.ExternalServices;
using Telegram.Bot;

namespace AssistantBot.Infrastructure.Telegram.Services;

public class TelegramBotService : ITelegramBotService
{
    private readonly ITelegramBotClient _botClient;

    public TelegramBotService(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task SendWelcomeMessage(long chatId)
    {
        
    }
    
    public async Task EditToMainMenuAsync(long chatId)
    {
        throw new NotImplementedException();
    }

    public async Task EditToNoteMenuAsync(long chatId)
    {
        throw new NotImplementedException();
    }

    public async Task EditToAiChatAsync(long chatId)
    {
        throw new NotImplementedException();
    }

    public async Task EditToWeatherMenuAsync(long chatId)
    {
        throw new NotImplementedException();
    }
}