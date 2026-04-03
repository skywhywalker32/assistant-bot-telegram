using AssistantBot.Application.Common.UI;
using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantBot.Infrastructure.Telegram.UI;

public static class InlineMarkupFactory
{
    public static InlineKeyboardMarkup MainMenu()
    {
        var buttons = new List<List<InlineKeyboardButton>>()
        {
            new List<InlineKeyboardButton>()
            { 
                InlineKeyboardButton.WithCallbackData(BotButtons.MainMenu.Note, BotCallbacks.MainMenu.NoteMenuCallback)
            },
            new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData(BotButtons.MainMenu.Weather, BotCallbacks.MainMenu.WeatherMenuCallback),
                InlineKeyboardButton.WithCallbackData(BotButtons.MainMenu.Weather, BotCallbacks.MainMenu.WeatherMenuCallback)
            }
        };

        return new InlineKeyboardMarkup(buttons);
    }
}