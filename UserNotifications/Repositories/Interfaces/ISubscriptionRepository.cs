using UserNotifications.Enums;
using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptionByStatus(int statusId); //filtrar por cada subscriçao que tenha o status ativo ou não
        Task<Subscription> GetSubscriptionByUser(int userId); //filtrar subscrição por usuário
        Task<bool> SubmitUserSubscription(int userId, string notification); //Como vou diferenciar as subscription com ID somente? E passar essas subscritpion para userID
        
    }
}
