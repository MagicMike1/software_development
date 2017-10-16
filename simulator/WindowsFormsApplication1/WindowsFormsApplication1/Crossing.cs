using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Crossing
    {
        Bitmap background;
        List<TrafficLight> lights;
        List<Movable> movables;
        List<List<Point>> paths;
        List<TrafficObject> trackTrees;

        public Crossing(Bitmap background, List<TrafficLight> lights, List<Movable> movables, List<List<Point>> paths, List<TrafficObject> trackTrees)
        {
            this.background = background;
            this.lights = lights;
            this.movables = movables;
            this.paths = paths;
            this.trackTrees = trackTrees;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(background,0,0, Settings.CanvasWidth, Settings.CanvasHeight);
            foreach(TrafficLight light in lights)
            {
                light.draw(g);
            }
            foreach(Movable movable in movables)
            {
                movable.draw(g);
            }
        }
    }
}
