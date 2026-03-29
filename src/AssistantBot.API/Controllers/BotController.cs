using AssistantBot.Application.Abstractions.ExternalServices;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace AssistantBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BotController : ControllerBase
{
    private readonly IBotUpdateTypeRouter _botUpdateTypeRouter;

    public BotController(IBotUpdateTypeRouter botUpdateTypeRouter)
    {
        _botUpdateTypeRouter = botUpdateTypeRouter;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        _botUpdateTypeRouter.HandleUpdate(update);
        
        return Ok();
    }
}