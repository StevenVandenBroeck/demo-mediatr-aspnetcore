﻿using System;
using System.Threading;
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
            var msg = $"Handled in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) - {notification.Message})";
            _messageSource.Add(msg);
            return Task.CompletedTask;
        }
    }
}
