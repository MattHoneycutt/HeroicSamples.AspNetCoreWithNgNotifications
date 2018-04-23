using Microsoft.AspNetCore.Mvc;

namespace HeroicSamples.AspNetCoreWithNgNotifications.Controllers.Notifications
{
    public static class NotificationExtensions
    {
        public static IActionResult WithSuccess(this IActionResult result, string title, string body)
        {
            return Notification(result, "success", title, body);
        }

        public static IActionResult WithInfo(this IActionResult result, string title, string body)
        {
            return Notification(result, "info", title, body);
        }

        public static IActionResult WithAlert(this IActionResult result, string title, string body)
        {
            return Notification(result, "alert", title, body);
        }

        public static IActionResult WithWarning(this IActionResult result, string title, string body)
        {
            return Notification(result, "warn", title, body);
        }

        public static IActionResult WithError(this IActionResult result, string title, string body)
        {
            return Notification(result, "error", title, body);
        }

        private static IActionResult Notification(IActionResult result, string type, string title, string body)
        {
            return new NotificationDecoratorResult(result, type, title, body);
        }
    }
}
