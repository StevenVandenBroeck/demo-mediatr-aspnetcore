using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Eventing
{
    public class AsyncAppEvent : IAsyncNotification, IAsyncRequest
    {
    }
}
