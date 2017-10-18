using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

class Movable : TrafficObject
{
    private double speed;

    public Movable(Image image) : base(image)//Vector2 position, Vector2 direction, int width, int height, Image image, double speed) : base(position, direction, width, height, image)
    {
		
        //this.speed = speed;
    }

	public void moveUp()
	{
		Thickness m = image.Margin;
		m.Top += 1;
		image.Margin = m;
		image.RenderTransform = new RotateTransform(90);
	}

    public void followPath(List<Point> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            position += direction * speed;
        }
    }
}
