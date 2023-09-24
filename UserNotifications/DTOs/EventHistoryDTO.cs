using System.ComponentModel.DataAnnotations;
using UserNotifications.Models;

namespace UserNotifications.Api.DTOs
{
    public class EventHistoryDTO
    {
        [Key]
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; internal set; }

        public Subscription? Subscription { get; set; }
    }
}
