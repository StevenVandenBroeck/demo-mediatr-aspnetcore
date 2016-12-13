using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace MediatrDemo.Eventing
{
    public interface IEventPublisher
    {
        Task PublishAsync(CancellableAsyncAppEvent appEvent, CancellationToken cancellationToken);
        void Publish(AppEvent appEvent);
        Task PublishAsync(AsyncAppEvent appEvent);
    }
}
