using System.ComponentModel.DataAnnotations;
using UserNotifications.Models;

namespace UserNotifications.Api.DTOs
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime CreateAt { get; internal set; }

        public Subscription? Subscription { get; set; }
    }
}
