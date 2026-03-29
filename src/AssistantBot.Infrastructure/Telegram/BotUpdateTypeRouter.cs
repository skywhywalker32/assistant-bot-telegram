using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.DTOs;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AssistantBot.Infrastructure.Telegram;

public class BotUpdateTypeRouter : IBotUpdateTypeRouter
{
    private readonly ILocationsReadService _locationsReadService;
    private readonly ILocationsWriteService _locationsWriteService;
    private readonly ITelegramBotService _botService;

    public BotUpdateTypeRouter(ILocationsReadService locationsReadService,
                               ILocationsWriteService locationsWriteService,
                               ITelegramBotService botService)
    {
        _locationsReadService = locationsReadService;
        _locationsWriteService = locationsWriteService;
        _botService = botService;
    }
    
    public async Task HandleUpdate(object update)
    {
        var updateToHandle = (Update?)update;

        if (updateToHandle is { } upd) // если не null
        {
            if (upd.Message is { } msg) // eсли пришёл тип "Сообщение"
            {
                if (msg.Location is { } location) // Локация
                {
                    // 1. Маппинг данных к Dto
                    var locationDto = new LocationDto()
                    {
                        Latitude = location.Latitude.ToString("D2"),
                        Longitude = location.Longitude.ToString("D2"),
                        ChatId = msg.Chat.Id
                    };
                    
                    // 2. Вызов соответствующего метода у сервиса из application
                    await _locationsWriteService.AddLocationAsync(locationDto);

                    // 3. Вызов метода из сервиса бота для отображения ответа
                }
            }

            if (updateToHandle.CallbackQuery is { }) // eсли пришёл тип "запрос обратного вызова"
            {
                
            }
        }
        
        
        
        throw new NotImplementedException();
    }
}