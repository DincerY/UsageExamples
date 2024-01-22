using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;


namespace RabbitMQUsage.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private string RabbitMQConnectionString { get; set; } =
        "";

    public OrderController()
    {
        CreateConnection(RabbitMQConnectionString);
    }
 
    [HttpGet]
    [Route("/queue")]
    public string QueueMessage()
    {
        return "View()";
    }

    private void CreateConnection(string connectionString)
    {
        var uri = "";

        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri(uri);
        IConnection connection = factory.CreateConnection();

        IModel channel = connection.CreateModel();
        
        
        

        string queueName = "create_order_queue";
        
        //Kuyruğu oluşturma kısımı eğer böyle bir kuyruk varsa oluşturmak yerine bağlanacak kısım.
        channel.QueueDeclare(queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        string message = "Hello RabbitMQ";

        var body = Encoding.UTF8.GetBytes(message);
        
        
        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: queueName,
            basicProperties: null,
            body: body);
    }
}