using System.ComponentModel.DataAnnotations;

namespace UserNotifications.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string? StatusName { get; set; }

        public Subscription? Subscription { get; set; }
    }
}
