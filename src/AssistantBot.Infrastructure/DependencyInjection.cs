using AssistantBot.Application.Abstractions.ExternalServices;
using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Repositories;
using AssistantBot.Infrastructure.Telegram;
using AssistantBot.Infrastructure.Telegram.Services;
using Microsoft.EntityFrameworkCore;
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

        services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"));
        });

        services.AddScoped<ILocationsRepository, LocationsRepository>();
        services.AddScoped<INotesRepository, NotesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ITelegramBotService, TelegramBotService>();
        services.AddScoped<IBotUpdateTypeRouter, BotUpdateTypeRouter>();
        
        return services;
    }
}