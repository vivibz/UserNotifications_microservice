using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatus();
        //Task<Status> GetActiveStatus();
        //Task<Status> GetInactiveStatus();
     
    }
}
