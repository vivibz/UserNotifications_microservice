using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface IEventHistoryRepository
    {

        // Buscar todos os registros
        Task<IEnumerable<EventHistory>> GetAllEvents();
        
        // Buscar um registro ppor subscription ID
        Task<EventHistory> GetEventBySubscriptionId(int subscriptionId);

        // Buscar todos os registros de EventHistory ocorridos em um intervalo de tempo específico (por exemplo, entre duas datas)
        Task<List<EventHistory>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
