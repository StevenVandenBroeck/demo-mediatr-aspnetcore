using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Eventing
{
    public class BaseAsyncAppEventHandler : IAsyncNotificationHandler<BaseAsyncAppEvent>
    {
        public BaseAsyncAppEventHandler(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task Handle(BaseAsyncAppEvent notification)
        {
            Thread.Sleep(3000);

            var msg = $"Handled in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) - {notification.Message})";
            _messageSource.Add(msg);
            return Task.CompletedTask;
        }
    }
}
