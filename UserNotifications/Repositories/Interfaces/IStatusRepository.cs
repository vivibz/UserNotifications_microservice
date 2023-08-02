using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        Task<Status> GetActiveStatus();
        Task<Status> GetInactiveStatus();
        Task<List<Status>> GetAllStatus();
    }
}
