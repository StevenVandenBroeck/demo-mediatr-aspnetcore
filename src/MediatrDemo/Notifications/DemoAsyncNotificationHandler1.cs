using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class DemoAsyncNotificationHandler1 : IAsyncNotificationHandler<DemoAsyncNotification>
    {
        public DemoAsyncNotificationHandler1(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task Handle(DemoAsyncNotification notification)
        {
            Thread.Sleep(5000);

            var msg = $"From {this.GetType().Name} - {notification.Message}";
            _messageSource.Add(msg);
            return Task.CompletedTask;
        }
    }
}
