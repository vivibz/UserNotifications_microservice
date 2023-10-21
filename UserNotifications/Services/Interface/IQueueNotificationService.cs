namespace UserNotifications.Api.Services.Interface
{
    public interface IQueueNotificationService
    {
        Task<bool> Publish(int userId, string notification);
    }
}
