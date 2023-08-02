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
        public Task<IEnumerable<EventHistory>> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Task<EventHistory> GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventHistory>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
