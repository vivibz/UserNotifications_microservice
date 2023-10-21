using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> Create(User user);
    }
}
