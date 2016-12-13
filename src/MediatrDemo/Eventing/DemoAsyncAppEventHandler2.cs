using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Eventing
{
    public class DemoAsyncAppEventHandler2 : IAsyncNotificationHandler<DemoAsyncAppEvent>
    {
        public DemoAsyncAppEventHandler2(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task Handle(DemoAsyncAppEvent notification)
        {
            Thread.Sleep(2000);
            throw new Exception($"Error thrown by {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})");

            var msg = $"Handled in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) - {notification.Message})";
            _messageSource.Add(msg);
            return Task.CompletedTask;
        }
    }
}
