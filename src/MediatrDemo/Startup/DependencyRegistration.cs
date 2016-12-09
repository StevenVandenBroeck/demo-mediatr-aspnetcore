using System;
using System.Collections.Generic;
using MediatR;
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

            services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
            services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));

            services.AddScoped<IMediator, Mediator>();

            return services;
        }

        private static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
        {
            return (IEnumerable<object>)provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
        }
    }
}
