using System.ComponentModel.DataAnnotations;

namespace UserNotifications.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime CreateAt { get; internal set; }

        public Subscription? Subscription { get; set; }
    }
}
