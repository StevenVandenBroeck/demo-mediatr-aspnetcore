using System;
using System.Collections.Generic;
using MediatR;
using MediatrDemo.Eventing;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrDemo
{
    public static class EventPublisherStartupExtensions
    {
        public static IServiceCollection AddEventing(this IServiceCollection services, Action<EventingOptions> setupAction = null)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IEventPublisher, EventPublisher>();

            services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
            services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));

            if ( setupAction != null )
            {
                services.Configure(setupAction);
                var options = new EventingOptions();
                setupAction.Invoke(options);

                var handlerType = options.ExceptionHandlerType ?? typeof(DefaultEventingExceptionHandler);
                services.AddScoped(typeof(IEventingExceptionHandler), handlerType);
            }

            return services;
        }

        private static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
        {
            return (IEnumerable<object>)provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
        }
    }
}
