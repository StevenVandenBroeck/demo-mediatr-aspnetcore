using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Eventing
{
    public class BaseAsyncAppEvent : AsyncAppEvent
    {
        public string Message { get; set; }
    }
}
