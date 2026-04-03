using AssistantBot.Domain.Entities;
using AssistantBot.Domain.Enums;
using Telegram.Bot.Types;
using User = AssistantBot.Domain.Entities.User;

namespace AssistantBot.Infrastructure.Telegram.Handlers;

public interface IMenuHandler
{
    MenuState State { get; }
    Task HandleAsync(Update update, User user);
}