using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace AssistantBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BotController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        return Ok();
    }
}