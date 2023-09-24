using System.ComponentModel.DataAnnotations;
using UserNotifications.Models;

namespace UserNotifications.Api.DTOs
{
    public class StatusDTO
    {
        [Key]
        public int Id { get; set; }
        public string? StatusName { get; set; }

        public Subscription? Subscription { get; set; }
    }
}
