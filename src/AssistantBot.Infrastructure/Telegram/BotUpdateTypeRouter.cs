using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.DTOs;
using AssistantBot.Domain.Enums;
using AssistantBot.Infrastructure.Extensions.Telegram;
using AssistantBot.Infrastructure.Telegram.Handlers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AssistantBot.Infrastructure.Telegram;

public class BotUpdateTypeRouter : IBotUpdateTypeRouter
{
    private readonly ILocationsReadService _locationsReadService;
    private readonly ILocationsWriteService _locationsWriteService;
    private readonly IUsersReadService _usersReadService;
    private readonly IUsersWriteService _usersWriteService;
    private readonly ITelegramBotService _botService;
    private readonly MenuContext _menuContext;

    public BotUpdateTypeRouter(ILocationsReadService locationsReadService,
                               ILocationsWriteService locationsWriteService,
                               IUsersReadService usersReadService,
                               IUsersWriteService usersWriteService,
                               ITelegramBotService botService,
                               MenuContext menuContext)
    {
        _locationsReadService = locationsReadService;
        _locationsWriteService = locationsWriteService;
        _usersReadService = usersReadService;
        _usersWriteService = usersWriteService;
        _botService = botService;
        _menuContext = menuContext;
    }
    
    public async Task HandleUpdateAsync(object update)
    {
        if (update is Update upd)
        {
            var chatIdOrNull = upd.GetChatIdOrDefault();

            if (chatIdOrNull is { } chatId)
            {
                var user = await _usersReadService.GetByChatIdAsync(chatId);

                if (user is null)
                {
                    var userDto = new UpsertUserDto()
                    {
                        ChatId = chatId,
                        Username = upd.GetUsernameOrDefault()
                    };
                    
                    user = await _usersWriteService.UpsertUserAsync(userDto);
                }

                if (user is null)
                {
                    throw new Exception("Unknown user");
                }
                
                await _menuContext.InvokeAsync(upd, user);
            }
        }
    }
}