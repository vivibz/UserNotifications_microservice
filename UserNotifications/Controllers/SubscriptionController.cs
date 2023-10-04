using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserNotifications.Api.Services.Interface;
using UserNotifications.Enums;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("statusId")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptionByStatus(int statusId) 
        {
            if (statusId == 0)
                return BadRequest();

            return Ok( await _subscriptionService.GetSubscriptionByStatus(statusId));
        }

        [HttpGet("userId")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptionByUser(int userId) 
        {
            if (userId == 0)
                return BadRequest();

            return Ok(await _subscriptionService.GetSubscriptionByUser(userId));
        }

        [HttpPost("submitSubscription")]
        public async Task<ActionResult<Subscription>> SubmitUserSubscription(int userId, string notification)
        {
            if (userId == 0)
                return BadRequest();
            
            return Ok (await _subscriptionService.SubmitUserSubscription(userId, notification));

        }


    }
}
