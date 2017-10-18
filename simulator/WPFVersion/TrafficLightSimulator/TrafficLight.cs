using System.Windows.Controls;

class TrafficLight// : TrafficObject
{
	int id { get; set; }
	int status { get; set; }
	public TrafficLight(int id, int status)//Image image) : base(image)//int id, int status, Vector2 position, Vector2 direction, int width, int height, Image image) : base(position, direction, width, height, image)
	{
		this.id = id;
		this.status = status;
	}
}
