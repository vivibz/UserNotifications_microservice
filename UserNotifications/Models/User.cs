using System.ComponentModel.DataAnnotations;

namespace UserNotifications.Models
{
    public class User
    {
        public User(int id)
        {
            Id = id;
        }

        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime CreateAt { get; internal set; }

        public Subscription? Subscription { get; set; }
    }
}
