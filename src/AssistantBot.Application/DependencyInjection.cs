using AssistantBot.Application.Abstractions.InternalServices;
using AssistantBot.Application.Services.Reads;
using AssistantBot.Application.Services.Writes;
using Microsoft.Extensions.DependencyInjection;

namespace AssistantBot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ILocationsReadService, LocationsReadService>();   
        services.AddScoped<ILocationsWriteService, LocationsWriteService>();   
        services.AddScoped<INotesReadService, NotesReadService>();   
        services.AddScoped<INotesWriteService, NotesWriteService>();   
        services.AddScoped<IUsersReadService, UsersReadService>();   
        services.AddScoped<IUsersWriteService, UsersWriteService>();   
        
        return services;
    }
}