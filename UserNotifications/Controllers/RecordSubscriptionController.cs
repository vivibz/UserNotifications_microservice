using Microsoft.AspNetCore.Mvc;

namespace UserNotifications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordSubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
