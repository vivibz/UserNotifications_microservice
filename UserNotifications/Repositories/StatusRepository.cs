using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Status>> GetAllStatus()  // TODO: Procurar por tipo de status, passando o enurable
        {
            return await _context.Status.ToListAsync();
        }

        //public Task<Status> GetInactiveStatus()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
