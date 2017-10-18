using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

class TrafficObject
{
    public Vector2 position { get; set; }
    public Vector2 direction { get; set; }
    private readonly int width, height;
    protected readonly Image image;

    public TrafficObject(Image image)//Vector2 position, Vector2 direction, int width, int height, Image image)
    {
        //this.position = position;
        //this.direction = direction;
        //this.width = width;
        //this.height = height;
        this.image = image;
    }

    public Image rotateImage(Image image)
    {
        return image;
    }

    //public void draw(Graphics g)
    //{       
    //    g.DrawImage(image, (float)position.X, (float)position.Y, width, height);
    //}
}
