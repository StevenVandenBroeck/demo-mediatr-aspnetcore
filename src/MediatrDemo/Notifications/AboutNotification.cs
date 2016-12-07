using System;
using MediatR;

namespace MediatrDemo.Notifications
{
    public class AboutNotification : IAsyncNotification
    {
        public string Message { get; set; }
    }
}
