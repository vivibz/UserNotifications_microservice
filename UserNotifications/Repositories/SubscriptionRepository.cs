using Microsoft.EntityFrameworkCore;
using UserNotifications.Context;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subscription>> GetSubscriptionByStatus(int statusId)
        {
            return await _context.Subscriptions.Include(s => s.Status).Where(s => s.StatusId == statusId).ToListAsync();
        }

        public Task<IEnumerable<User>> GetSubscriptionByUser()
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> SubmitUserSubscription(Subscription userId, Subscription id)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> UpdateSubscription(Subscription userId)
        {
            throw new NotImplementedException();
        }
    }
}
