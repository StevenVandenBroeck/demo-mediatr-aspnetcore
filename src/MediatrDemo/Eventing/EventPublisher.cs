using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;

namespace MediatrDemo.Eventing
{
    public class EventPublisher : IEventPublisher
    {
        public EventPublisher(IMediator mediator, IOptions<EventingOptions> options, IEventingExceptionHandler exceptionHandler)
        {
            _mediator = mediator;
            _options = options.Value;
            _exceptionHandler = exceptionHandler;
        }

        private readonly IMediator _mediator;
        private readonly EventingOptions _options;
        private readonly IEventingExceptionHandler _exceptionHandler;

        public void Publish(AppEvent appEvent)
        {
            _mediator.Publish(appEvent);
        }

        public async Task PublishAsync(AsyncAppEvent appEvent)
        {
            await Task.Run(() => {
                try
                {
                    return _mediator.PublishAsync(appEvent);
                }
                catch ( Exception ex )
                {
                    _exceptionHandler.Handle(ex);
                    return Task.FromException(ex);
                }
            });
        }

        public async Task PublishAsync(CancellableAsyncAppEvent appEvent, CancellationToken cancellationToken)
        {
            await Task.Run(() => {
                try
                {
                    return _mediator.PublishAsync(appEvent, cancellationToken);
                }
                catch ( Exception ex )
                {
                    _exceptionHandler.Handle(ex);
                    return Task.FromException(ex);
                }
            });
        }
    }
}
