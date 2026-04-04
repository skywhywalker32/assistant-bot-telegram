using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Common.UI;
using AssistantBot.Infrastructure.Telegram.UI;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace AssistantBot.Infrastructure.Telegram.Services;

public class TelegramBotService : ITelegramBotService
{
    private readonly ITelegramBotClient _botClient;

    public TelegramBotService(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task SendWelcomeMessageAsync(long chatId)
    {
        await _botClient.SendMessage(chatId, BotTexts.Welcome);

        await Task.Delay(1000);

        await _botClient.SendMessage(chatId, BotTexts.MainMenu, replyMarkup: InlineMarkupFactory.MainMenu());
    }
    
    public async Task EditToMainMenuAsync(long chatId, int msgId)
    {
        await _botClient.EditMessageText(chatId, msgId, BotTexts.MainMenu, replyMarkup: InlineMarkupFactory.MainMenu());
    }

    public async Task EditToNoteMenuAsync(long chatId, int msgId)
    {
        await _botClient.EditMessageText(chatId, msgId, BotTexts.NoteMenu, replyMarkup: InlineMarkupFactory.NoteMenu());
    }

    public async Task EditToAiChatAsync(long chatId, int msgId)
    {
        await _botClient.EditMessageText(chatId, msgId, BotTexts.AiChat, replyMarkup: InlineMarkupFactory.AiChat());
    }

    public async Task EditToWeatherMenuAsync(long chatId, int msgId)
    {
        await _botClient.EditMessageText(chatId, msgId, BotTexts.WeatherMenu, replyMarkup: InlineMarkupFactory.WeatherMenu());
    }
}