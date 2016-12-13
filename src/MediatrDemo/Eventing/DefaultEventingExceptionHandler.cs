using System;
using System.Diagnostics;

namespace MediatrDemo.Eventing
{
    public class DefaultEventingExceptionHandler : IEventingExceptionHandler
    {
        public void Handle(Exception ex)
        {
            Debug.WriteLine($"Exception sending event(s) : {ex.Message}");
        }
    }
}
