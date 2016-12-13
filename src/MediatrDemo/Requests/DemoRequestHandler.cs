using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDemo.Requests
{
    public class DemoRequestHandler : IAsyncRequestHandler<DemoRequest, bool>
    {
        public DemoRequestHandler(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public Task<bool> Handle(DemoRequest message)
        {
            var msg = $"Handled in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) - {message.Message})";
            _messageSource.Add(msg);
            return Task.FromResult(true);
        }
    }
}
