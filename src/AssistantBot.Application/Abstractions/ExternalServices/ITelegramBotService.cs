namespace AssistantBot.Application.Abstractions.ExternalServices;

public interface ITelegramBotService
{
    Task<int> SendWelcomeMessageAsync(long chatId);
    Task<int> EditOrSendToMainMenuAsync(long chatId, int msgId);
    Task<int> EditOrSendToNoteMenuAsync(long chatId, int msgId);
    Task<int> EditOrSendToAiChatAsync(long chatId, int msgId);
    Task<int> EditOrSendToWeatherMenuAsync(long chatId, int msgId);
}