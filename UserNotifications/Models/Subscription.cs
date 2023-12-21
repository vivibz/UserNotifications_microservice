using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserNotifications.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; } //relacionar o id do usuário 
        public int StatusId { get; set; }

        public DateTime CreatedAt { get; internal set; }
        public DateTime? UpdateAt { get; set; }

        public User? User { get; set; } //trazer os dados do usuário 
        public Status? Status { get; set; }

        public List<EventHistory>? EventHistory { get; set; }
    }
}
