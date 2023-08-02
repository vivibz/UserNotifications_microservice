using UserNotifications.Context;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Status> GetActiveStatus()
        {
            throw new NotImplementedException();
        }

        public Task<List<Status>> GetAllStatus()
        {
            throw new NotImplementedException();
        }

        public Task<Status> GetInactiveStatus()
        {
            throw new NotImplementedException();
        }
    }
}
