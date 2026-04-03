namespace AssistantBot.Application.Abstractions.ExternalServices;

public interface ITelegramBotService
{
    Task EditToMainMenuAsync(long chatId);
    Task EditToNoteMenuAsync(long chatId);
    Task EditToAiChatAsync(long chatId);
    Task EditToWeatherMenuAsync(long chatId);
}