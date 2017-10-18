using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace TrafficLightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		RabbitHandler r;
		Movable movingCar;
		public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 100); 
            dt.Start();
			r = new RabbitHandler();
			movingCar = new Movable(Car);
		}

        private void timer_Tick(object sender, EventArgs e)
        {
			movingCar.moveUp();
			r.Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			r.Start();
        }

    }
}
