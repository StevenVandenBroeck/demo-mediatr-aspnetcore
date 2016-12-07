using System;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class AboutNotificationHandler : IAsyncNotificationHandler<AboutNotification>
    {
        public AboutNotificationHandler(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task Handle(AboutNotification notification)
        {
            var msg = $"{this.GetType().Name} - {notification.Message}";
            _messageSource.Add(msg);
            return Task.FromResult(0);
        }
    }
}
