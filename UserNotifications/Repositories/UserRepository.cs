using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserNotifications.Context;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> Create(User user)
        {
            _context.Users.Add(user); 
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
