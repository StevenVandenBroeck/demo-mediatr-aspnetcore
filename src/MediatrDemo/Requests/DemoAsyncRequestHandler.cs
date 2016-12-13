using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Requests
{
    public class DemoAsyncRequestHandler : IAsyncRequestHandler<DemoAsyncRequest, bool>
    {
        public DemoAsyncRequestHandler(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task<bool> Handle(DemoAsyncRequest message)
        {
            Thread.Sleep(5000);

            var msg = $"Handled in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) - {message.Message})";
            _messageSource.Add(msg);
            return Task.FromResult(true);
        }
    }
}
