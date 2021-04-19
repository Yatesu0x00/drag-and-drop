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
using System.Windows.Shapes;

namespace DragAndDrop
{
    public partial class startDlg : Window
    {
        public double breite { get; set; }

        public startDlg()
        {
            Background = Brushes.Gainsboro;

            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                breite = Convert.ToDouble(tbLeange.Text);

                if(breite < 10 || breite > 100)
                {
                    throw new Exception("Wert der Seitenlänge zwischen 10 und 100");
                }
                else
                {
                    DialogResult = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message, "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void tbLeange_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
    }
}
