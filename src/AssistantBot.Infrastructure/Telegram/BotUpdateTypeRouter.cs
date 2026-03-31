using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.DTOs;
using AssistantBot.Infrastructure.Extensions.Telegram;
using AssistantBot.Infrastructure.Telegram.MenuStates;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AssistantBot.Infrastructure.Telegram;

public class BotUpdateTypeRouter : IBotUpdateTypeRouter
{
    private readonly ILocationsReadService _locationsReadService;
    private readonly ILocationsWriteService _locationsWriteService;
    private readonly ITelegramBotService _botService;
    private readonly MenuContext _menuContext;

    public BotUpdateTypeRouter(ILocationsReadService locationsReadService,
                               ILocationsWriteService locationsWriteService,
                               ITelegramBotService botService,
                               MenuContext menuContext)
    {
        _locationsReadService = locationsReadService;
        _locationsWriteService = locationsWriteService;
        _botService = botService;
        _menuContext = menuContext;
    }
    
    public async Task HandleUpdateAsync(object update)
    {
        if (update is Update upd)
        {
            var chatId = upd.GetChatIdOrDefault();
            
            // Нужно получить состояние меню и состояние дейсвия пользователя (главное меню, меню заметок и тд.) из бд
            
            var menuContext = new MenuContext();
            
            switch (upd.Type)
            {
                case UpdateType.Message:
                {
                    menuContext.ProcessMessage();
                    break;
                }

                case UpdateType.CallbackQuery:
                {
                    menuContext.ProcessCallback();
                    break;
                }
            }
        }
    }
}