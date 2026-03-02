using Microsoft.Extensions.DependencyInjection;

namespace AssistantBot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}