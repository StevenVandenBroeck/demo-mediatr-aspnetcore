using System;
using System.Threading;

namespace MediatrDemo.Eventing
{
    public class MyEventingExceptionHandler : IEventingExceptionHandler
    {
        public MyEventingExceptionHandler(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        private readonly IMessageSource _messageSource;

        public void Handle(Exception ex)
        {
            _messageSource.Add($"Exception handled in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})");
        }
    }
}
