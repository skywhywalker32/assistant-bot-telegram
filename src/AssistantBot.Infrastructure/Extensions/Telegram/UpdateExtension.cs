using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AssistantBot.Infrastructure.Extensions.Telegram;

public static class UpdateExtension
{
    public static long? GetChatIdOrDefault(this Update update)
    {
        long? chatId = update.Type switch
        {
            UpdateType.Message => update?.Message?.From?.Id,
            UpdateType.CallbackQuery => update?.CallbackQuery?.Message?.From?.Id,
            _ => null
        };
        
        return chatId;
    }
}