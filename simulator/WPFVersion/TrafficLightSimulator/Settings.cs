using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Settings
{
    //canvas
    public static Size ClientResolution { get; private set; }
    public static int CanvasWidth { get; private set; }
    public static int CanvasHeight { get; private set; }
    public static int timerSpeed { get; private set; } = 16; //speed for the the timer in milliseconds

    //images
    public static string backgroundImage = "D:\\School\\software development\\background1.png";
    public static string trafficLightImage = "D:\\School\\software development\\trafficlight.png";
    public static string trackTreeImage = "D:\\School\\software development";

    //object size
    public static int TrafficLightWidth = 40;
    public static int TrafficLightHeight = 60;

    public static void SetClientResolution(Size resolution) => ClientResolution = resolution;
    public static void SetCanvasWidth(int width) { if (width <= ClientResolution.Width) CanvasWidth = width; }
    public static void SetCanvaHeight(int height) { if (height <= ClientResolution.Height) CanvasHeight = height; }
}
