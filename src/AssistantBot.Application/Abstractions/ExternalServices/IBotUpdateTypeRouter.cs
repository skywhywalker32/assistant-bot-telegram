namespace AssistantBot.Application.Abstractions.ExternalServices;

public interface IBotUpdateTypeRouter
{
    Task HandleUpdate(object update);
}