using Microsoft.EntityFrameworkCore;
using UserNotifications.Context;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Repositories
{
    public class EventHistoryRepository : IEventHistoryRepository
    {
        private readonly AppDbContext _context;

        public EventHistoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EventHistory>> GetAllEvents()
        {
            return await _context.EventHistory.ToListAsync();
        }

        public async Task<EventHistory> GetEventBySubscriptionId(int subscriptionId)
        {
            return await _context.EventHistory.Include(s => s.Subscription).Where(e => e.SubscriptionId == subscriptionId).FirstOrDefault();
        }

        public Task<List<EventHistory>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
