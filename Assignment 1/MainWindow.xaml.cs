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

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush color = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        
       

        public MainWindow()
        {
            InitializeComponent();
            //setting up the range of the sliders
            x.Minimum = y.Minimum = z.Minimum = a.Minimum = 0;
            x.Maximum = y.Maximum = z.Maximum = a.Maximum = 255;

            //forcing integer values
            a.TickFrequency = 1;
            x.TickFrequency = 1;
            y.TickFrequency = 1;
            z.TickFrequency = 1;

            //forcing integer values cont....
            a.IsSnapToTickEnabled = true;
            x.IsSnapToTickEnabled = true;
            y.IsSnapToTickEnabled = true;
            z.IsSnapToTickEnabled = true;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random number = new Random();

            //Changing slider locations and recording color
            a.Value = 255; // no transparency for random color
            x.Value = number.Next(255);
            y.Value = number.Next(255);
            z.Value = number.Next(255);

            //setting color
            color.Color = Color.FromArgb((byte)a.Value,(byte)x.Value, (byte)y.Value, (byte)z.Value);

            colorChange(color);
           /* for (byte i = 0; i < 255; i++)
            {
                for (byte j = 0; j < 255; j++)
                {
                    for (byte k = 0; k < 255; k++)
                    {
                        color.Color = Color.FromRgb(i, j, k);
                        MyRectangle.Fill = color;
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
            */
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            color.Color = Color.FromArgb((byte) a.Value,(byte)x.Value, (byte)y.Value, (byte)z.Value);
            colorChange(color); 
        }
        private void colorChange(SolidColorBrush color)
        {
            
            //Changes Color
            
            MyRectangle.Fill = color;

            //Displays info about it
            ColorDisplay.Text = "RGB value: " + x.Value.ToString() + " " + y.Value.ToString() + " " + z.Value.ToString() + " Hex ARGB Value: " + color.Color.ToString();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            //for closing the window
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {//For moving the window
            this.DragMove();
            
        }


    }
}
