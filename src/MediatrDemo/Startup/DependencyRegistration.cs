using System;
using System.Collections.Generic;
using MediatR;
using MediatrDemo.Eventing;
using MediatrDemo.Notifications;
using MediatrDemo.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrDemo
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<IMessageSource, MessageSource>();

            services.AddScoped<IAsyncNotificationHandler<DemoNotification>, DemoNotificationHandler1>();
            services.AddScoped<IAsyncNotificationHandler<DemoNotification>, DemoNotificationHandler2>();
            services.AddScoped<IAsyncNotificationHandler<DemoAsyncNotification>, DemoAsyncNotificationHandler1>();
            services.AddScoped<IAsyncNotificationHandler<DemoAsyncNotification>, DemoAsyncNotificationHandler2>();

            services.AddScoped<IAsyncRequestHandler<DemoRequest, bool>, DemoRequestHandler>();
            services.AddScoped<IAsyncRequestHandler<DemoAsyncRequest, bool>, DemoAsyncRequestHandler>();

            services.AddScoped<IAsyncNotificationHandler<DemoAsyncAppEvent>, DemoAsyncAppEventHandler1>();
            services.AddScoped<IAsyncNotificationHandler<DemoAsyncAppEvent>, DemoAsyncAppEventHandler2>();
            services.AddScoped<IAsyncNotificationHandler<BaseAsyncAppEvent>, BaseAsyncAppEventHandler>();

            return services;
        }
    }
}
