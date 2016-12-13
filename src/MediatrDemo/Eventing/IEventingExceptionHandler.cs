using System;

namespace MediatrDemo.Eventing
{
    public interface IEventingExceptionHandler
    {
        void Handle(Exception ex);
    }
}
