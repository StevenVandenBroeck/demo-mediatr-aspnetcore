using System;
using MediatR;
using MediatrDemo.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrDemo
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<IMessageSource, MessageSource>();

            services.AddScoped<IAsyncNotificationHandler<AboutNotification>, AboutNotificationHandler>();

            return services;
        }
    }
}
