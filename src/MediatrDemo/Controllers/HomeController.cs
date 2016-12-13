using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Eventing;
using MediatrDemo.Notifications;
using MediatrDemo.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediatrDemo.Controllers
{
    [SuppressMessage("CS4014", "CS4014")]
    public class HomeController : Controller
    {
        public HomeController(IMediator mediator, IMessageSource messageSource, IEventPublisher eventPublisher)
        {
            _mediator = mediator;
            _messageSource = messageSource;
            _eventPublisher = eventPublisher;
        }

        private readonly IMediator _mediator;
        private readonly IMessageSource _messageSource;
        private readonly IEventPublisher _eventPublisher;

        public IActionResult Index()
        {
            return View(_messageSource.Messages);
        }

        public async Task<IActionResult> PublishEvent()
        {
            var notification = new DemoNotification() { Message = $"event published on {DateTime.Now} in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            _mediator.PublishAsync(notification);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SendEvent()
        {
            var demoRequest = new DemoRequest() { Message = $"event sent on {DateTime.Now} in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            _mediator.SendAsync(demoRequest);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PublishAsyncEvent()
        {
            var notification = new DemoAsyncNotification() { Message = $"event published on {DateTime.Now} in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            Task.Run(() => {
                try
                {
                    _mediator.PublishAsync(notification);
                }
                catch ( Exception ex )
                {
                    _messageSource.Add($"exception caught in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}): {ex.Message}");
                }
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SendAsyncEvent()
        {
            var demoRequest = new DemoAsyncRequest() { Message = $"event sent on {DateTime.Now} in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            Task.Run(() => {
                try
                {
                    _mediator.SendAsync(demoRequest);
                }
                catch ( Exception ex )
                {
                    _messageSource.Add($"exception caught in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}) : {ex.Message}");
                }
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PublishAsyncEventViaPublisher()
        {
            try
            {
                var notification = new DemoAsyncAppEvent() { Message = $"app-event published on {DateTime.Now} in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
                _eventPublisher.PublishAsync(notification);
            }
            catch ( Exception ex )
            {
                // exception never gets to here since we don't await
                _messageSource.Add($"exception caught in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}): {ex.Message}");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PublishAsyncEventViaPublisherAwait()
        {
            try
            {
                var notification = new DemoAsyncAppEvent() { Message = $"app-event published on {DateTime.Now} in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
                await _eventPublisher.PublishAsync(notification);
            }
            catch ( Exception ex )
            {
                // exception is caught here because we awaited
                _messageSource.Add($"exception caught in {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId}): {ex.Message}");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
