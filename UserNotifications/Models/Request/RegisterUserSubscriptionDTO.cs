namespace UserNotifications.Api.Models.Request
{
    public class RegisterUserSubscriptionDTO
    {
        public int UserId { get; set; }
        public string? Notification { get; set; }
    }
}
