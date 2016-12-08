using System;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class DemoNotification : IAsyncNotification
    {
        public string Message { get; set; }
    }
}
