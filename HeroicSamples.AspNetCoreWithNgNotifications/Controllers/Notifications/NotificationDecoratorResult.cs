using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeroicSamples.AspNetCoreWithNgNotifications.Controllers.Notifications
{
    public class NotificationDecoratorResult : IActionResult
    {
        public IActionResult Result { get; }
        public string Type { get; }
        public string Title { get; }
        public string Body { get; }

        public NotificationDecoratorResult(IActionResult result, string type, string title, string body)
        {
            Result = result;
            Type = type;
            Title = title;
            Body = body;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add("x-notification-type", Type);
            context.HttpContext.Response.Headers.Add("x-notification-title", Title);
            context.HttpContext.Response.Headers.Add("x-notification-body", Body);

            await Result.ExecuteResultAsync(context);
        }
    }
}