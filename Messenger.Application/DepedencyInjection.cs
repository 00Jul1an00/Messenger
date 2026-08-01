using Messenger.Application.Interfaces;
using Messenger.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMessageService, MessageService>();
        return services;
    }
}