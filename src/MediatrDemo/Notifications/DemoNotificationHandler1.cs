using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class DemoNotificationHandler1 : IAsyncNotificationHandler<DemoNotification>
    {
        public DemoNotificationHandler1(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task Handle(DemoNotification notification)
        {
            Task.Run(() => this.HandleInternal(notification));
            return Task.CompletedTask;
        }

        private void HandleInternal(DemoNotification notification)
        {
            throw new Exception("error in Handler 1");

            Thread.Sleep(5000);

            var msg = $"From {this.GetType().Name} - {notification.Message}";
            _messageSource.Add(msg);
        }
    }
}
