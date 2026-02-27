using Telegram.Bot;
using Telegram.Bot.Polling;

namespace AssistantBot.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSingleton<ITelegramBotClient>(provider =>
        {
            var token =
                builder.Configuration.GetSection("BotToken").Value
                ?? throw new Exception("No token");

            return new TelegramBotClient(token);
        });

        var app = builder.Build();

        await using (var scope = app.Services.CreateAsyncScope())
        {
            var bot = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
            var hostUrl = builder.Configuration["HostUrl"]
                          ?? throw new Exception("No URL");

            await bot.SetWebhook($"{hostUrl}/api/bot");
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}