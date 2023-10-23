using RabbitMQ.Client;
using UserNotifications.Api.Services.Interface;
using System.Text.Json;
using System.Text;

namespace UserNotifications.Api.Services
{
    public class QueueNotificationService : IQueueNotificationService
    {// para isolar a lógica de comunicação com rabbit, pois no service subsc... ficaria poluído
        public Task<bool> Publish(int userId, string notification)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "rabbit1",
                Password = "Numsey@Password!",
            };

            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Subscriptions",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(new { userId = userId, notification = notification });

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Subscriptions",
                                     basicProperties: null,
                                     mandatory: true,
                                     body: body);

                return Task.FromResult(true);
            }
        }
    }
}
