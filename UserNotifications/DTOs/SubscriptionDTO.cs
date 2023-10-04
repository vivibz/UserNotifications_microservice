using System.ComponentModel.DataAnnotations;
using UserNotifications.Models;

namespace UserNotifications.Api.DTOs
{
    public class SubscriptionDTO
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; } 
        public int StatusId { get; set; }

        public DateTime CreatedAt { get; internal set; }
        public DateTime UpdateAt { get; set; }

        public User? User { get; set; }
        public Status? Status { get; set; }

        public List<EventHistory>? EventHistory { get; set; }
    }
}
