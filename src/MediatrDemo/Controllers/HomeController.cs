﻿using System;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Notifications;
using MediatrDemo.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediatrDemo.Controllers
{
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

        public async Task<IActionResult> Publish()
        {
            var notification = new DemoNotification() { Message = $"event published on {DateTime.Now}" };
            await _mediator.PublishAsync(notification);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Send()
        {
            var demoRequest = new DemoRequest() { Message = $"event sent on {DateTime.Now}" };
            await _mediator.SendAsync(demoRequest);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
