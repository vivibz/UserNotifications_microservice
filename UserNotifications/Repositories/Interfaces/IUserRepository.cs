using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetById(int id);
    }
}
