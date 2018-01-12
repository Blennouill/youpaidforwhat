using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Domain.Shared.Models;
using ShareFlow.Interface.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareFlow.Interface.Middlewares
{
    /// <summary>
    /// Is used to add an envelop to the return response if needed
    /// </summary>
    public class ResponseDecoratingMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseDecoratingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, INotificationService notificationService)
        {
            // before
            await _next(httpContext);

            // after
            var notifications = notificationService.GetNotifications();
            if (notifications.Any())
            {
                var body = httpContext.Response.Body.ToString();
                List<InformationModel> informationModels = new List<InformationModel>();
                foreach (var notification in notifications)
                {
                    informationModels.Add(new InformationModel()
                    {
                        Id = notification.Id,
                        Message = new Message(notification.Value)
                    });
                }

                JObject response = new JObject();

                response.Add(body);
                response.Add(informationModels);

                await httpContext.Response.WriteAsync(response.ToString());
            }
        }
    }
}