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
                InlineKeyboardButton.WithCallbackData(BotButtons.MainMenu.AIChat, BotCallbacks.MainMenu.AIChatCallback)
            }
        };

        return new InlineKeyboardMarkup(buttons);
    }

    public static InlineKeyboardMarkup NoteMenu()
    {
        var buttons = new List<List<InlineKeyboardButton>>()
        {
            new List<InlineKeyboardButton>()
            { 
                InlineKeyboardButton.WithCallbackData(BotButtons.NoteMenu.PrintAll, BotCallbacks.NoteMenu.PrintAll)
            },
            new List<InlineKeyboardButton>()
            {
                InlineKeyboardButton.WithCallbackData(BotButtons.NoteMenu.Add, BotCallbacks.NoteMenu.Add)
            },
            new List<InlineKeyboardButton>()
            { 
                InlineKeyboardButton.WithCallbackData(BotButtons.NoteMenu.Back, BotCallbacks.NoteMenu.Back)
            },
        };

        return new InlineKeyboardMarkup(buttons);
    }

    public static InlineKeyboardMarkup WeatherMenu()
    {
        var buttons = new List<List<InlineKeyboardButton>>()
        {
            new List<InlineKeyboardButton>()
            { 
                InlineKeyboardButton.WithCallbackData(BotButtons.WeatherMenu.Location, BotCallbacks.WeatherMenu.Location)
            },
            new List<InlineKeyboardButton>()
            { 
                InlineKeyboardButton.WithCallbackData(BotButtons.WeatherMenu.Back, BotCallbacks.WeatherMenu.Back)
            },
        };
        
        return new InlineKeyboardMarkup(buttons);
    }

    public static InlineKeyboardMarkup AiChat()
    {
        var buttons = new List<List<InlineKeyboardButton>>()
        {
            new List<InlineKeyboardButton>()
            { 
                InlineKeyboardButton.WithCallbackData(BotButtons.AiChat.Back, BotCallbacks.AiChat.Back)
            },
        };
        
        return new InlineKeyboardMarkup(buttons);
    }
}