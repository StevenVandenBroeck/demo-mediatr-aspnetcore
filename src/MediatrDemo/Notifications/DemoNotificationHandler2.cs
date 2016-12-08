using System;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class DemoNotificationHandler2 : IAsyncNotificationHandler<DemoNotification>
    {
        public DemoNotificationHandler2(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task Handle(DemoNotification notification)
        {
            var msg = $"From {this.GetType().Name} - {notification.Message}";
            _messageSource.Add(msg);
            return Task.FromResult(0);
        }
    }
}
