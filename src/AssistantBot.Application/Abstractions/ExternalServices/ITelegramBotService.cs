namespace AssistantBot.Application.Abstractions.ExternalServices;

public interface ITelegramBotService
{
    Task HandleMessage();
    Task HandleCallbackQuery();
}