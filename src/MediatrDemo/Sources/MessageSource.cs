using System;
using System.Collections.Generic;

namespace MediatrDemo
{
    public class MessageSource : IMessageSource
    {
        public MessageSource()
        {
            _messages = new List<string>();
        }

        private ICollection<string> _messages;
        public IEnumerable<string> Messages
        {
            get
            {
                return _messages;
            }
        }

        public void Add(string message)
        {
            _messages.Add(message);
        }
    }
}
