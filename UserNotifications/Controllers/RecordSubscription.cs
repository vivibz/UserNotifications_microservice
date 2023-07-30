using Microsoft.AspNetCore.Mvc;

namespace UserNotifications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordSubscription : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
