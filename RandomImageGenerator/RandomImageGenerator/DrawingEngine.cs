using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RandomImageGenerator
{
    using System.Windows.Media;
    using System.Windows;
    using System.Reflection;

    public class DrawingEngine
    {
        private volatile bool _shouldStop;
        private volatile Int32 _threadDelay;
        private DrawingGroup _dg;

        public DrawingEngine(DrawingContext dc)
        {
            //this._dg = dg;
        }

        public void Draw()
        {
            //while (!_shouldStop)
            //{
            //    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(()=> MainWindow.Update))
            //    System.Console.WriteLine("scheduled");
            //    Thread.Sleep(_threadDelay);
            //}
        }

        public void SetDelay(Int32 delay)
        {
            _threadDelay = delay;
        }

        public void RequestStop()
        {
            _shouldStop = true; 
        }
    }

}
