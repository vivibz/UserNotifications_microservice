﻿using AutoMapper;
using UserNotifications.Api.DTOs;
using UserNotifications.Api.Services.Interface;
using UserNotifications.Enums;
using UserNotifications.Models;
using UserNotifications.Repositories;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Api.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public SubscriptionService(IMapper mapper, ISubscriptionRepository subscriptionRepository)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<IEnumerable<SubscriptionDTO>> GetSubscriptionByStatus(int statusId)
        {
            var subscriptionStatus = await _subscriptionRepository.GetSubscriptionByStatus(statusId);
            return _mapper.Map<IEnumerable<SubscriptionDTO>>(subscriptionStatus);
        }
        public async Task<IEnumerable<SubscriptionDTO>> GetSubscriptionByUser(int userId)
        {
            var subscriptionUser = await _subscriptionRepository.GetSubscriptionByUser(userId);
            return _mapper.Map<IEnumerable<SubscriptionDTO>>(subscriptionUser);
        }
        public async Task<SubscriptionDTO> SubmitUserSubscription(int userId, string notification)
        {
            var subscription = await _subscriptionRepository.SubmitUserSubscription(userId, notification);
            return _mapper.Map<SubscriptionDTO>(subscription);
        }
    }
}