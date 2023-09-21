using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserNotifications.Enums;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet("statusId")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptionByStatus(int statusId) 
        {
            if (statusId == 0)
                return BadRequest();

            return Ok( await _subscriptionRepository.GetSubscriptionByStatus(statusId));
        }

        [HttpGet("userId")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptionByUser(int userId) 
        {
            if (userId == 0)
                return BadRequest();

            return Ok(await _subscriptionRepository.GetSubscriptionByUser(userId));
        }

        [HttpPost("submitSubscription")]
        public async Task<ActionResult<Subscription>> SubmitUserSubscription(int userId, int subscription)
        {
            if (userId == 0)
                return BadRequest();
            
            return Ok (await _subscriptionRepository.SubmitUserSubscription(userId, subscription));

        }


    }
}
