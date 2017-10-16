using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Bitmap backbuffer;
        private Timer gameTimer;
        private int frameCount, fps;
        private DateTime startTime;
        private Brush brush;
        private Crossing crossing;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer, true);

            this.ResizeEnd += new EventHandler(Form1_CreateBackBuffer);
            this.Load += new EventHandler(Form1_CreateBackBuffer);
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.SetClientResolution(ClientSize);
            Settings.SetCanvasWidth(ClientSize.Width);
            Settings.SetCanvaHeight(ClientSize.Height);

            gameTimer = new Timer();
            gameTimer.Interval = Settings.timerSpeed;
            gameTimer.Tick += new EventHandler(GameTimer_Tick);

            frameCount = 0;
            startTime = new DateTime();
            brush = new SolidBrush(Color.Blue);

            initializeCrossing();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (backbuffer != null)
            {
                e.Graphics.DrawImageUnscaled(backbuffer, Point.Empty);
            }
        }

        void Form1_CreateBackBuffer(object sender, EventArgs e)
        {
            if (backbuffer != null)
                backbuffer.Dispose();

            backbuffer = new Bitmap(Settings.CanvasWidth, Settings.CanvasHeight);
        }


        void GameTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;

            if (elapsedTime.Seconds >= 1)
            {
                fps = frameCount;
                startTime = DateTime.Now;
                frameCount = 0;
            }

            if (backbuffer != null)
            {
                using (Graphics g = Graphics.FromImage(backbuffer))
                {
                    crossing.draw(g);
                    g.DrawString("FPS: " + fps, new Font(FontFamily.GenericMonospace, 20), brush, Settings.CanvasWidth - 200, 0);
                    
                }

                frameCount++;
                Invalidate();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }

        private void initializeCrossing()
        {
            List<TrafficLight> lights = new List<TrafficLight>();
            //Road lights
            lights.Add(new TrafficLight(101, 0, new Vector2(565, 180), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(102, 0, new Vector2(650, 180), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(103, 0, new Vector2(810, 180), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(104, 0, new Vector2(900, 400), new Vector2(0, 1), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(105, 0, new Vector2(10, 10), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(106, 0, new Vector2(10, 10), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(107, 0, new Vector2(10, 10), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(108, 0, new Vector2(10, 10), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(109, 0, new Vector2(10, 10), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));
            lights.Add(new TrafficLight(110, 0, new Vector2(10, 10), new Vector2(1, 0), Settings.TrafficLightWidth, Settings.TrafficLightHeight, new Bitmap(Settings.trafficLightImage)));

            List<Movable> movables = new List<Movable>();
            List<List<Point>> paths = new List<List<Point>>();
            List<TrafficObject> trackTrees = new List<TrafficObject>();

            crossing = new Crossing(new Bitmap(Settings.backgroundImage), lights, movables, paths, trackTrees);
        }
    }
}
