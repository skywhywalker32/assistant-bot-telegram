using AssistantBot.Domain.Enums;
using Telegram.Bot.Types;
using User = AssistantBot.Domain.Entities.User;

namespace AssistantBot.Infrastructure.Telegram.Handlers;

public class MenuContext
{
    private readonly IEnumerable<IMenuHandler> _handlers;

    public MenuContext(IEnumerable<IMenuHandler> handlers)
    {
        _handlers = handlers;
    }

    public async Task InvokeAsync(Update update, User user)
    {
        var handler = _handlers.First(h => h.State == user.MenuState);

        await handler.HandleAsync(update, user);
    }
}