using Financial.Framework.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Financial.Framework.Api
{
    [ApiController]
    public class RestApi<T> : ControllerBase
    {
        protected readonly IMediator Mediator;
        protected readonly INotificationService NotificationService;
        protected readonly ILogger<T> Logger;

        public RestApi(IMediator mediator, INotificationService notificationService, ILogger<T> logger)
        {
            Mediator = mediator;
            NotificationService = notificationService;
            Logger = logger;
        }

        protected async Task<IActionResult> GetResultAsync(object command, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return await GetResultAsync(async () => await Mediator.Send(command), statusCode);
        }

        protected async Task<IActionResult> GetResultAsync(Func<Task<object>> func, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            try
            {
                var data = await func();

                var response = new
                {
                    data,
                    notifications = NotificationService.GetNotifications()
                };

                if (NotificationService.HasNotifications())
                {
                    Logger.LogWarning("Request errors: {@notifications}", response.notifications);
                    statusCode = HttpStatusCode.BadRequest;
                }

                NotificationService.Clear();

                return new ObjectResult(response)
                {
                    StatusCode = (int)statusCode
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Api request call error {@Target}", func.Target);
            }

            return new ObjectResult(null) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }
    }
}