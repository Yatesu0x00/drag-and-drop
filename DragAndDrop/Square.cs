using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragAndDrop
{
    class Square
    {
        public Rectangle Rect { get; set; }
        private bool isGrabbed;

        public Square(double breite)
        {
            Rect = new Rectangle();

            Rect.Fill = Brushes.Black;
            Rect.Width = breite;
            Rect.Height = breite;

            Canvas.SetLeft(Rect, 250);
            Canvas.SetTop(Rect, 150);
        }

        public void Grab()
        {
            isGrabbed = true;
        }

        public void Drop()
        {
            isGrabbed = false;
        }

        public void Drag(double PosX, double PosY)
        {
            if (isGrabbed)
            {
                Canvas.SetLeft(Rect, PosX - Rect.Width/2);
                Canvas.SetTop(Rect, PosY - Rect.Height/2);
            }
        }
    }
}
