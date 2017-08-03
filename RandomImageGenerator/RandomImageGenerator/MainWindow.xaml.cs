using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomImageGenerator
{
    using System.Reflection;
    using System.Windows.Media;
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Width of output drawing
        /// </summary>
        private const float RenderWidth = 640.0f;

        /// <summary>
        /// Height of our output drawing
        /// </summary>
        private const float RenderHeight = 480.0f;

        /// <summary>
        /// Drawing image that we will display
        /// </summary>
        private DrawingImage imageSource;

        /// <summary>
        /// Drawing group for points rendering output
        /// </summary>
        private DrawingGroup drawingGroup;

        private Thread _workerThread;

        private DrawingEngine _myEngine;

        private Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // Create the drawing group we'll use for drawing
            this.drawingGroup = new DrawingGroup();

            // Create an image source that we can use in our image control
            this.imageSource = new DrawingImage(this.drawingGroup);
            //_myEngine = new DrawingEngine(this.drawingGroup);
            //_myEngine.SetDelay(2000); // 2000 msec of delay
            Image.Source = this.imageSource;
            _workerThread = new Thread(ImageThread);
            _workerThread.Start();
        }

        private void ImageThread()
        {
            while (true)
            {
                Dispatcher.BeginInvoke((Action)CreateShape);
                Thread.Sleep(500);
            }
        }

        private void CreateShape()
        {
            using (DrawingContext dc = this.drawingGroup.Open())
            {
                dc.DrawRectangle(Brushes.Black, null, new Rect(0.0, 0.0, RenderWidth, RenderHeight));
                for (int i = 0; i < 10000; i++)
                {
                    
                    int xPos = _random.Next(0, (int)RenderWidth);
                    int yPos = _random.Next(0, (int)RenderHeight);
                    dc.DrawEllipse(PickBrush(), null, new Point(xPos, yPos), 0.5, 0.5);
                }
                
            }
            
            System.Console.WriteLine("tread");
        }

        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _workerThread.Join();
        }

        private void UpdateImage(string image)
        {
            System.Console.WriteLine(image);
        }
    }
}
