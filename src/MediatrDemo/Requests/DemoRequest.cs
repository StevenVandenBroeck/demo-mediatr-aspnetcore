using System;
using MediatR;

namespace MediatrDemo.Requests
{
    public class DemoRequest : IAsyncRequest<bool>
    {
        public string Message { get; set; }
    }
}
