using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BotController : ControllerBase
{
    private readonly ITelegramBotClient _bot;

    public BotController(ITelegramBotClient bot)
    {
        _bot = bot;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        return Ok();
    }
}