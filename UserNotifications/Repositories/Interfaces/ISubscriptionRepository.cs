using UserNotifications.Enums;
using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptionByStatus(int statusId); //filtrar por cada subscriçao que tenha o status ativo ou não
        Task<IEnumerable<Subscription>> GetSubscriptionByUser(int userId); //filtrar subscrição por usuário
        Task<Subscription> SubmitUserSubscription(int userId, ESubscription subscription); //Como vou diferenciar as subscription com ID somente? E passar essas subscritpion para userID
        Task<Subscription> UpdateSubscription(int userId, ESubscription subscription); //atualizar subscrição 
        
    }
}
