using System;

namespace MediatrDemo.Eventing
{
    public class EventingOptions
    {
        public Type ExceptionHandlerType { get; private set; } = typeof(DefaultEventingExceptionHandler);

        public void RegisterExceptionHandler<TType>() where TType : IEventingExceptionHandler
        {
            ExceptionHandlerType = typeof(TType);
        }
    }
}
