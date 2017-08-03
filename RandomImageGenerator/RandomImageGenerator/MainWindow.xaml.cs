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

		private int minimumPoints = 1;
		private int maximumPoints = 100000;
		private double minimumDiameter = 0.5;
		private double maximumDiameter = 10;

        private Random _random = new Random();
		private Random _randomDiam = new Random();

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
            
            Image.Source = this.imageSource;
            //_workerThread = new Thread(ImageThread);
            //_workerThread.Start();
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
                for (int i = 0; i < 100000; i++)
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

		private void generateButton_Click(object sender, RoutedEventArgs e)
		{
			//first check that all the inputs are within the limits
			int numberOfPoints = Convert.ToInt32(pointsNumberTextBox.Text);
			double dotDiameters = Convert.ToDouble(diameterTextBox.Text);
			if (numberOfPoints >= minimumPoints && numberOfPoints <= maximumPoints)
			{
				if (dotDiameters >= minimumDiameter && dotDiameters <= maximumDiameter)
				{
					//ok, execute the algorithms
					this.Draw(numberOfPoints, dotDiameters, randomizeDiamaters.IsChecked ?? false, verticalMirror.IsChecked ?? false, horizontalMirror.IsChecked ?? false);
				}
				else
				{
					MessageBox.Show("The diameter is outside the limits", "Input error", MessageBoxButton.OK);
				}
			}
			else
			{
				MessageBox.Show("Number of points are outside the limits", "Input error", MessageBoxButton.OK);
			}
		}

		private void Draw(int points, double diameter, bool randomizeDiameter, bool mirrorVertical, bool mirrorHorizontal)
		{
			double tempDiameter = diameter;
			int xPos;
			int yPos;
			using (DrawingContext dc = this.drawingGroup.Open())
			{
				dc.DrawRectangle(Brushes.Black, null, new Rect(0.0, 0.0, RenderWidth, RenderHeight));
				for (int i = 0; i < points; i++)
				{
					if (randomizeDiameter)
					{
						tempDiameter = _randomDiam.NextDouble() * diameter;
					}
					if (mirrorVertical && mirrorHorizontal)
					{
						xPos = _random.Next(0, (int)RenderWidth/2);
						yPos = _random.Next(0, (int)RenderHeight/2);
						//first quadrant
						dc.DrawEllipse(PickBrush(), null, new Point(RenderWidth / 2 - xPos, RenderHeight / 2 + yPos), tempDiameter, tempDiameter);
						//second
						dc.DrawEllipse(PickBrush(), null, new Point(RenderWidth / 2 + xPos, RenderHeight / 2 + yPos), tempDiameter, tempDiameter);
						//third
						dc.DrawEllipse(PickBrush(), null, new Point(RenderWidth / 2 + xPos, RenderHeight / 2 - yPos), tempDiameter, tempDiameter);
						//fourth
						dc.DrawEllipse(PickBrush(), null, new Point(RenderWidth / 2 - xPos, RenderHeight / 2 - yPos), tempDiameter, tempDiameter);
					}
					if (mirrorVertical)
					{
						xPos = _random.Next(0, (int)RenderWidth / 2);
						yPos = _random.Next(0, (int)RenderHeight);
						dc.DrawEllipse(PickBrush(), null, new Point(RenderWidth / 2 - xPos, yPos), tempDiameter, tempDiameter);
						dc.DrawEllipse(PickBrush(), null, new Point(RenderWidth / 2 + xPos, yPos), tempDiameter, tempDiameter);
					}
					if (mirrorHorizontal)
					{
						xPos = _random.Next(0, (int)RenderWidth);
						yPos = _random.Next(0, (int)RenderHeight / 2);
						dc.DrawEllipse(PickBrush(), null, new Point(xPos, RenderHeight / 2 - yPos), tempDiameter, tempDiameter);
						dc.DrawEllipse(PickBrush(), null, new Point(xPos, RenderHeight / 2 + yPos), tempDiameter, tempDiameter);
					}
					if (!mirrorVertical && !mirrorHorizontal)
					{
						xPos = _random.Next(0, (int)RenderWidth);
						yPos = _random.Next(0, (int)RenderHeight);
						dc.DrawEllipse(PickBrush(), null, new Point(xPos, yPos), tempDiameter, tempDiameter);
					}

					
				}
			}
		}

		private void Window_Closed(object sender, EventArgs e)
		{

		}
	}
}
