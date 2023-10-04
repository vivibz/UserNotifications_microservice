using UserNotifications.Api.DTOs;
using UserNotifications.Enums;
using UserNotifications.Models;

namespace UserNotifications.Api.Services.Interface
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDTO>> GetSubscriptionByStatus(int statusId); //filtrar por cada subscriçao que tenha o status ativo ou não
        Task<IEnumerable<SubscriptionDTO>> GetSubscriptionByUser(int userId); //filtrar subscrição por usuário
        Task<SubscriptionDTO> SubmitUserSubscription(int userId, string notification); //Como vou diferenciar as subscription com ID somente? E passar essas subscritpion para userID
    }
}
