using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TrafficObject
    {
        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }
        private readonly int width, height;
        private readonly Bitmap image;

        public TrafficObject(Vector2 position, Vector2 direction, int width, int height, Bitmap image)
        {
            this.position = position;
            this.direction = direction;
            this.width = width;
            this.height = height;
            this.image = image;
        }

        public Bitmap rotateImage(Bitmap image)
        {
            return image;
        }

        public void draw(Graphics g)
        {       
            g.DrawImage(image, (float)position.X, (float)position.Y, width, height);
        }
    }
}
