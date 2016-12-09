using System;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class DemoAsyncNotification : IAsyncNotification
    {
        public string Message { get; set; }
    }
}
