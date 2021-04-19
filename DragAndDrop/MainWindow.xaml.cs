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
    public partial class MainWindow : Window
    {
        Square square;
        startDlg dlg;
        double offset_x, offset_y;

        public MainWindow()
        {
            Background = Brushes.Gainsboro;

            dlg = new startDlg();

            if ((bool)dlg.ShowDialog())
            {
                InitializeComponent();
            }
            else
            {
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            square = new Square(dlg.breite);
            if (!c.Children.Contains(square.Rect))
            {
                c.Children.Add(square.Rect);
            }
            Console.WriteLine(dlg.breite);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (square.Rect.IsMouseOver)
            {
                square.Grab();
            }            
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            square.Drop();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(window);
            new Point(window.Left + point.X, window.Top + point.Y);
            
            x.Content = "X: " + point.X;
            y.Content = "Y: " + point.Y;

            offset_x = point.X;
            offset_y = point.Y;

            square.Drag(offset_x, offset_y);
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            square.Drop();
        }
    }
}
