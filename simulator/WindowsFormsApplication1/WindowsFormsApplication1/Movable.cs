using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Movable : TrafficObject
    {
        private double speed;

        public Movable(Vector2 position, Vector2 direction, int width, int height, Bitmap image, double speed) : base(position, direction, width, height, image)
        {
            this.speed = speed;
        }

        public void followPath(List<Point> path)
        {
            for (int i = 0; i < path.Count; i++)
            {
                position += direction * speed;
            }
        }
    }
}
