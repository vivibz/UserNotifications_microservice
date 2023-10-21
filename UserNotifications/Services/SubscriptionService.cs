using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IQueueNotificationService _queueNotificationService;
        public SubscriptionService(IMapper mapper, ISubscriptionRepository subscriptionRepository, IQueueNotificationService queueNotificationService)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _queueNotificationService = queueNotificationService;
        }
        public async Task<IEnumerable<SubscriptionDTO>> GetSubscriptionByStatus(int statusId)
        {
            if (statusId == 0)
                throw new Exception("StatusId is not valid");

            var subscriptionStatus = await _subscriptionRepository.GetSubscriptionByStatus(statusId);
            return _mapper.Map<IEnumerable<SubscriptionDTO>>(subscriptionStatus);
        }
        public async Task<IEnumerable<SubscriptionDTO>> GetSubscriptionByUser(int userId)
        {
            if (userId == 0)
                throw new Exception("UserId is not valid");

            var subscriptionUser = await _subscriptionRepository.GetSubscriptionByUser(userId);
            return _mapper.Map<IEnumerable<SubscriptionDTO>>(subscriptionUser);
        }
        public async Task<string> SubmitUserSubscription(int userId, string notification)
        {
            if (userId == 0)
                throw new Exception("UserID is not valid");

           var notificationSent = await _queueNotificationService.Publish(userId, notification);
            if (notificationSent)
            {
                return notification; 
            } else
            {
                throw new Exception("Notification not sent");
            }
        }
        public async Task<bool> RegisterUserSubscription(int userId, string notification)
        {
            return await _subscriptionRepository.SubmitUserSubscription(userId, notification);
        }// enviando para o repository os dados necessário para salvar a subscrtiopn do usuário 
    }
}
