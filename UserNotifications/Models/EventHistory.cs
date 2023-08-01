using System.ComponentModel.DataAnnotations;

namespace UserNotifications.Models
{
    public class EventHistory
    {
        [Key]
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; internal set; }

        public Subscription? Subscription { get; set; }
    }
}
