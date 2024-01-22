using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

string RabbitMQConnectionString =
"";

ConnectionFactory connectionFactory = new ConnectionFactory();
connectionFactory.Uri = new Uri(RabbitMQConnectionString);
IConnection connection = connectionFactory.CreateConnection();

IModel channel = connection.CreateModel();

string queueName = "create_order_queue";

channel.QueueDeclare(queue: queueName,
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    byte[] body = ea.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Queue mesajı {message}");
};

channel.BasicConsume(queue: queueName,
    autoAck: true, 
    consumer: consumer);

Console.WriteLine("Mesajları dinlemek için bekleniyor. Çıkış yapmak için herhangi bir tuşa basın.");
Console.ReadLine();

