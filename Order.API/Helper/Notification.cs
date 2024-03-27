using RabbitMQ.Client;

namespace Order.API.Helper;


public class Notification
{
    private ConnectionFactory _connectionFactory;

    public Notification()
    {
        _connectionFactory = new ConnectionFactory();
        _connectionFactory.Uri = new Uri("amqp://guest:guest@localhost:5672");
        _connectionFactory.ClientProvidedName = "Order Service";

        var connection = _connectionFactory.CreateConnection();
        var channel = connection.CreateModel();
    }
}