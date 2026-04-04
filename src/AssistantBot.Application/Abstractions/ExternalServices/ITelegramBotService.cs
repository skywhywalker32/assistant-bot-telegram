namespace AssistantBot.Application.Abstractions.ExternalServices;

public interface ITelegramBotService
{
    Task SendWelcomeMessageAsync(long chatId);
    Task EditToMainMenuAsync(long chatId, int msgId);
    Task EditToNoteMenuAsync(long chatId, int msgId);
    Task EditToAiChatAsync(long chatId, int msgId);
    Task EditToWeatherMenuAsync(long chatId, int msgId);
}