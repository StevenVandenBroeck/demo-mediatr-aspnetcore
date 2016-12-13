using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class DemoAsyncNotificationHandler2 : IAsyncNotificationHandler<DemoAsyncNotification>
    {
        public DemoAsyncNotificationHandler2(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task Handle(DemoAsyncNotification notification)
        {
            Thread.Sleep(2000);
            throw new Exception($"Error thrown in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})");

            var msg = $"Handled in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) - {notification.Message})";
            _messageSource.Add(msg);
            return Task.CompletedTask;
        }
    }
}
