using System;
using MediatR;

namespace MediatrDemo.Requests
{
    public class DemoAsyncRequest : IAsyncRequest<bool>
    {
        public string Message { get; set; }
    }
}
