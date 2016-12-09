using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Notifications;
using MediatrDemo.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediatrDemo.Controllers
{
    [SuppressMessage("CS4014", "CS4014")]
    public class HomeController : Controller
    {
        public HomeController(IMediator mediator, IMessageSource messageSource)
        {
            _mediator = mediator;
            _messageSource = messageSource;
        }

        private readonly IMediator _mediator;
        private readonly IMessageSource _messageSource;

        public IActionResult Index()
        {
            return View(_messageSource.Messages);
        }

        public async Task<IActionResult> PublishEvent()
        {
            var notification = new DemoNotification() { Message = $"event published on {DateTime.Now}" };
            _mediator.PublishAsync(notification);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SendEvent()
        {
            var demoRequest = new DemoRequest() { Message = $"event sent on {DateTime.Now}" };
            _mediator.SendAsync(demoRequest);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PublishAsyncEvent()
        {
            var notification = new DemoAsyncNotification() { Message = $"event published on {DateTime.Now}" };
            Task.Run(() => {
                try
                {
                    _mediator.PublishAsync(notification);
                }
                catch ( Exception ex )
                {
                    _messageSource.Add($"exception caught in controller : {ex.Message}");
                }
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SendAsyncEvent()
        {
            var demoRequest = new DemoAsyncRequest() { Message = $"event sent on {DateTime.Now}" };
            Task.Run(() => {
                try
                {
                    _mediator.SendAsync(demoRequest);
                }
                catch ( Exception ex )
                {
                    _messageSource.Add($"exception caught in controller : {ex.Message}");
                }
            });
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
