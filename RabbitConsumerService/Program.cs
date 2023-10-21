using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "rabbit1",
            Password = "Numsey@Password!"
        };

        using (var connection = factory.CreateConnection()) 
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Subscriptions",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Recebida : {message}");

                    var contentString = new StringContent(message, Encoding.UTF8, "application/json"); //está dizendo para o metodo httpClient que o conteudo do body é uma string contendo um json 
                    
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.PostAsync("https://localhost:7268/api/Subscription/registerUserSubscription", contentString);
                    } // consumindo notification api para salvar no banco 

                };

                channel.BasicConsume(queue: "Subscriptions",
                                     autoAck: true,
                                     consumer: consumer);

                Console.ReadLine();
            }
        }

    }
    
}
