namespace AssistantBot.Application.Abstractions.ExternalServices;

public interface IBotUpdateTypeRouter
{
    Task HandleUpdateAsync(object update);
}