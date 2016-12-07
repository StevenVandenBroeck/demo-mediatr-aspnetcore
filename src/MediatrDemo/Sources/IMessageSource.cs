using System;
using System.Collections.Generic;

namespace MediatrDemo
{
    public interface IMessageSource
    {
        IEnumerable<string> Messages { get; }

        void Add(string message);
    }
}
