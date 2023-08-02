using UserNotifications.Models;

namespace UserNotifications.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptionByStatus(Subscription statusId); //filtrar por cada subscriçao que tenha o status ativo ou não
        Task<Subscription> SubmitUserSubscription(Subscription userId, Subscription id); //Como vou diferenciar as subscription com ID somente? E passar essas subscritpion para userID
        Task<Subscription> UpdateSubscription(Subscription userId); //atualizar subscrição 
        Task<IEnumerable<User>> GetSubscriptionByUser(); //filtrar subscrição por usuário
    }
}
