using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Eventing
{
    public class EventPublisher : IEventPublisher
    {
        public EventPublisher(IMediator mediator, IMessageSource messageSource)
        {
            _mediator = mediator;
            _messageSource = messageSource;
            
        }

        private readonly IMediator _mediator;
        private readonly IMessageSource _messageSource;

        public void Publish(AppEvent appEvent)
        {
            _mediator.Publish(appEvent);
        }

        public async Task PublishAsync(AsyncAppEvent appEvent)
        {
            _messageSource.Add($"Publishing event via {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})");

            await Task.Run(() => {
                try
                {
                    return _mediator.PublishAsync(appEvent);
                }
                catch ( Exception ex )
                {
                    _messageSource.Add($"exception caught in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) : {ex.Message})");
                    return Task.FromException(ex);
                }
            });
        }

        public Task PublishAsync(CancellableAsyncAppEvent appEvent, CancellationToken cancellationToken)
        {
            return _mediator.PublishAsync(appEvent, cancellationToken);
        }
    }
}
