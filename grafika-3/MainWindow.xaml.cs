using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace grafika_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int rValue = 0, gValue = 0, bValue = 0;

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;

            Regex rgbRegex = new Regex(@"^rgb.+");
            Regex cmykRegex = new Regex(@"^cmyk.+");
            Regex hsvRegex = new Regex(@"^hsv.+");

            if (!slider.IsMouseOver) return;

            if (rgbRegex.IsMatch(slider.Name))
            {

            }
            if (cmykRegex.IsMatch(slider.Name))
            {

            }
            if (hsvRegex.IsMatch(slider.Name))
            {

            }


        }
    }
}
