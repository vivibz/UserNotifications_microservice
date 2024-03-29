﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserNotifications.Api.Models.Request;
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
        public async Task<ActionResult<Subscription>> GetSubscriptionByUser(int userId) 
        {
            if (userId == 0)
                return BadRequest();

            return Ok(await _subscriptionService.GetSubscriptionByUser(userId));
        }

        [HttpPost("submitSubscription")]
        public async Task<ActionResult<Subscription>> SubmitUserSubscription([FromBody] RegisterUserSubscriptionDTO regiterUserSubscriptionDto)
        {
            if (regiterUserSubscriptionDto.UserId == 0)
                return BadRequest();

            
            return Ok (await _subscriptionService.SubmitUserSubscription(regiterUserSubscriptionDto.UserId, regiterUserSubscriptionDto.Notification));

        }

        [HttpPost("registerUserSubscription")]
        public async Task<ActionResult<bool>> RegisterUserSubscription([FromBody] RegisterUserSubscriptionDTO regiterUserSubscriptionDto)
        {
            if (regiterUserSubscriptionDto.UserId == 0 || regiterUserSubscriptionDto.Notification == null)
                return BadRequest();

            return Ok(await _subscriptionService.RegisterUserSubscription(regiterUserSubscriptionDto.UserId, regiterUserSubscriptionDto.Notification));
        }


    }
}
