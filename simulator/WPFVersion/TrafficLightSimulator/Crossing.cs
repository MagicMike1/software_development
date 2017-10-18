using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

class Crossing
{
    List<TrafficLight> lights;
    List<Movable> movables;
    List<List<Point>> paths;
    List<TrafficObject> trackTrees;

    public Crossing(List<TrafficLight> lights, List<Movable> movables, List<List<Point>> paths, List<TrafficObject> trackTrees)
    {
        this.lights = lights;
        this.movables = movables;
        this.paths = paths;
        this.trackTrees = trackTrees;
    }

    public void draw()
    {
        //g.DrawImage(background,0,0, Settings.CanvasWidth, Settings.CanvasHeight);
        //foreach(TrafficLight light in lights)
        //{
        //    light.draw(g);
        //}
        //foreach(Movable movable in movables)
        //{
        //    movable.draw(g);
        //}
    }
}

