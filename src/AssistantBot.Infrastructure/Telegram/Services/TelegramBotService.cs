using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Common.UI;
using AssistantBot.Infrastructure.Telegram.UI;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AssistantBot.Infrastructure.Telegram.Services;

public class TelegramBotService : ITelegramBotService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<TelegramBotService> _logger;

    public TelegramBotService(ITelegramBotClient botClient, ILogger<TelegramBotService> logger)
    {
        _botClient = botClient;
        _logger = logger;
    }

    public async Task<int> SendWelcomeMessageAsync(long chatId)
    {
        await _botClient.SendMessage(chatId, BotTexts.Welcome);

        await Task.Delay(1000);

        var message = 
            await _botClient.SendMessage(chatId, BotTexts.MainMenu, replyMarkup: InlineMarkupFactory.MainMenu());
        
        return message.Id;
    }
    
    public async Task<int> EditOrSendToMainMenuAsync(long chatId, int msgId)
    {
        Message message;
        
        try
        {
            message = await _botClient.EditMessageText(chatId, msgId, BotTexts.MainMenu, replyMarkup: InlineMarkupFactory.MainMenu());
        }
        catch (Exception e)
        {
            message = await _botClient.SendMessage(chatId, BotTexts.MainMenu, replyMarkup: InlineMarkupFactory.MainMenu());
            
            _logger.LogError(e, $"Не удалось отредактировать сообщение у юзера: {chatId} по messageId: {msgId}." +
                                $" Метод {nameof(EditOrSendToMainMenuAsync)}\n");
        }

        return message.Id;
    }

    public async Task<int> EditOrSendToNoteMenuAsync(long chatId, int msgId)
    {
        Message message;
        
        try
        {
            message = await _botClient.EditMessageText(chatId, msgId, BotTexts.NoteMenu, replyMarkup: InlineMarkupFactory.NoteMenu());
        }
        catch (Exception e)
        {
            message = await _botClient.SendMessage(chatId, BotTexts.NoteMenu, replyMarkup: InlineMarkupFactory.NoteMenu());
            
            _logger.LogError(e, $"Не удалось отредактировать сообщение у юзера: {chatId} по messageId: {msgId}." +
                                $" Метод {nameof(EditOrSendToNoteMenuAsync)}\n");
        }

        return message.Id;
    }

    public async Task<int> EditOrSendToAiChatAsync(long chatId, int msgId)
    {
        Message message;
        
        try
        {
            message = await _botClient.EditMessageText(chatId, msgId, BotTexts.AiChat, replyMarkup: InlineMarkupFactory.AiChat());
        }
        catch (Exception e)
        {
            message = await _botClient.SendMessage(chatId, BotTexts.AiChat, replyMarkup: InlineMarkupFactory.AiChat());
            
            _logger.LogError(e, $"Не удалось отредактировать сообщение у юзера: {chatId} по messageId: {msgId}." +
                                $" Метод {nameof(EditOrSendToAiChatAsync)}\n");
        }

        return message.Id;
    }

    public async Task<int> EditOrSendToWeatherMenuAsync(long chatId, int msgId)
    {
        Message message;
        
        try
        {
            message = await _botClient.EditMessageText(chatId, msgId, BotTexts.WeatherMenu, replyMarkup: InlineMarkupFactory.WeatherMenu());
        }
        catch (Exception e)
        {
            message = await _botClient.SendMessage(chatId, BotTexts.WeatherMenu, replyMarkup: InlineMarkupFactory.WeatherMenu());
            
            _logger.LogError(e, $"Не удалось отредактировать сообщение у юзера: {chatId} по messageId: {msgId}." +
                                $" Метод {nameof(EditOrSendToWeatherMenuAsync)}\n");
        }

        return message.Id;
    }
}