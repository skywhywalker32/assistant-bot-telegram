namespace AssistantBot.Infrastructure.Telegram.MenuStates;

public interface IMenuState
{
    Task HandleMessage(MenuContext menuContext);
    Task HandleCallbackQuery(MenuContext menuContext);
}