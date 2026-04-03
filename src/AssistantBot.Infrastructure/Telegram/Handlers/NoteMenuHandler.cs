using AssistantBot.Domain.Enums;
using Telegram.Bot.Types;
using User = AssistantBot.Domain.Entities.User;

namespace AssistantBot.Infrastructure.Telegram.Handlers;

public class NoteMenuHandler : IMenuHandler
{
    public MenuState State { get; } = MenuState.NoteMenu;

    public async Task HandleAsync(Update update, User user)
    {
        throw new NotImplementedException();
    }
}