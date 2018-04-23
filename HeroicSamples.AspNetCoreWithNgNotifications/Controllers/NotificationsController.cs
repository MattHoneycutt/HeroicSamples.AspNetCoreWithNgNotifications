using HeroicSamples.AspNetCoreWithNgNotifications.Controllers.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace HeroicSamples.AspNetCoreWithNgNotifications.Controllers
{
    [Route("api/[controller]/[action]"),
     ApiController]
    public class NotificationsController : Controller
    {
        [HttpGet]
        public IActionResult Success()
        {
            return Ok(new {id = 1, name = "success"}).WithSuccess("It worked!", "All is well...");
        }

        [HttpGet]
        public IActionResult Info()
        {
            return Ok(new {id = 2, name = "info"}).WithInfo("Info!", "Here is some information...");
        }

        [HttpGet]
        public IActionResult Alert()
        {
            return Ok(new {id = 3, name = "alert"}).WithAlert("Alert!", "Heads up...");
        }

        [HttpGet]
        public IActionResult Warning()
        {
            return Ok(new {id = 4, name = "warning"}).WithWarning("Warning!", "Better watch out...");
        }

        [HttpGet]
        public IActionResult Error()
        {
            return Ok().WithError("Error!", "That didn't work...");
        }
    }
}
