namespace AssistantBot.Application.Abstractions.ExternalServices;

public interface ITelegramBotService
{
    Task SendMainMenuAsync();
    Task SendNoteMenuAsync();
    Task SendAiChatAsync();
    Task SendWeatherMenuAsync();
}