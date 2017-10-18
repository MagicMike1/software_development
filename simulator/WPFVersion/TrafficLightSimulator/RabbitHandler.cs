using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class RabbitHandler
{
	private static readonly string queueName = "simulator";
	private static readonly string commandqueue = "controller";
	private int tempTime;
	private bool sendResponse = false;
	private static readonly ConnectionFactory factory = new ConnectionFactory() { HostName = "141.252.206.68", UserName = "test", Password = "test" };// VirtualHost = "/11"
	private static IConnection connection;
	private IModel channel;
	private EventingBasicConsumer simulatorConsumer;

	public RabbitHandler()
	{
		if (connection == null)
			connection = factory.CreateConnection();
		channel = connection.CreateModel();
		channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false);
		simulatorConsumer = new EventingBasicConsumer(channel);
		simulatorConsumer.Received += HandleControllerData;
		channel.BasicConsume(queue: queueName, autoAck: true, consumer: simulatorConsumer);
	}
	
	// Use this for initialization
	public void Start()
	{
		TrafficUpdate t = new TrafficUpdate(101, 1);
		string message = t.toJson();
		Console.WriteLine(message);
		var body = Encoding.UTF8.GetBytes(message);
		channel.BasicPublish(exchange: "",
								 routingKey: commandqueue,
								 basicProperties: null,
								 body: body);
	}

	private void HandleControllerData(object sender, BasicDeliverEventArgs e)
	{
		string tempR = Encoding.ASCII.GetString((e.Body));
		Console.WriteLine(tempR);
		string lightArray = JObject.Parse(tempR).SelectToken("Lights").ToString();
		TrafficLight[] recieved = JsonConvert.DeserializeObject<TrafficLight[]>(lightArray);
		Console.WriteLine("Message: " + recieved);

		tempTime = DateTime.Now.Second;
		Console.WriteLine(tempTime);
		this.sendResponse = true;
	}

	// Update is called once per frame
	public void Update()
	{
		if (tempTime + 5 < DateTime.Now.Second && this.sendResponse) {
			TrafficUpdate t = new TrafficUpdate(101, 0);
			string message = t.toJson();
			Console.WriteLine(message);
			var body = Encoding.UTF8.GetBytes(message);
			channel.BasicPublish(exchange: "",
									 routingKey: commandqueue,
									 basicProperties: null,
									 body: body);
			this.sendResponse = false;
		}
	}
}

class lightsCollection
{
	public Dictionary<string, TrafficLight> TrafficLights{ get; set; }

}

public class TrafficUpdate
{
	public int LightId;
	public int Count;
	public string DirectionRequest;

	public TrafficUpdate(int LightId, int Count, string DirectionRequest = null) {
		this.LightId = LightId;
		this.Count = Count;
		this.DirectionRequest = DirectionRequest;
	}

	public string toJson()
	{
		return "{ \"TrafficUpdate\": " + JsonConvert.SerializeObject(this) + "}";
	}
}

