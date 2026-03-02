using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace AssistantBot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITelegramBotClient>(provider =>
        {
            var token =
                configuration["BotToken"]
                ?? throw new Exception("Bot token not found in configuration");

            return new TelegramBotClient(token);
        });
        
        return services;
    }
}