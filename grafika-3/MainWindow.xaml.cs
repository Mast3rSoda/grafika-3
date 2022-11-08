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

        private float rValue = 0, gValue = 0, bValue = 0;
        private float cValue = 0, mValue = 0, yValue = 0, kValue = 0;
        private float hValue = 0, sValue = 0, vValue = 0;
        private float rP = 0, gP = 0, bP = 0;
        private float Cmax = 0, Cmin = 0, delta = 0;

        private void hsvHSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
        }

        private void cmykMSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;


            switch (slider.Name[4])
            {
                case 'C':
                    cValue = (float)Math.Round(slider.Value / 100.0, 2);
                    break;

                case 'M':
                    mValue = (float)Math.Round(slider.Value / 100.0, 2);
                    break;

                case 'Y':
                    yValue = (float)Math.Round(slider.Value / 100.0, 2);
                    break;
                case 'K':
                    kValue = (float)Math.Round(slider.Value / 100.0, 2);

                    break;
            }



            rgbRSlider.Value = rValue = 255 * (1 - cValue * (1 - kValue));
            rgbGSlider.Value = gValue = (float)Math.Round(255 * (1 - mValue * (1 - kValue)));
            rgbBSlider.Value = bValue = (float)Math.Round(255 * (1 - yValue * (1 - kValue)));

            if (kValue != 0)
            {

                rgbRSlider.Value = rValue = (float)Math.Round(Math.Max(0, rValue - (255 * kValue)));
                rgbGSlider.Value = gValue = (float)Math.Round(Math.Max(0, gValue - (255 * kValue)));
                rgbBSlider.Value = bValue = (float)Math.Round(Math.Max(0, bValue - (255 * kValue)));
            }



            changeColor();

        }

        private void rgbSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;

            switch (slider.Name[3])
            {
                case 'R':
                    rValue = Convert.ToByte(slider.Value);
                    break;

                case 'G':
                    gValue = Convert.ToByte(slider.Value);
                    break;

                case 'B':
                    bValue = Convert.ToByte(slider.Value);
                    break;
            }

            rP = (float)Math.Round(rValue / 255, 2);
            gP = (float)Math.Round(gValue / 255, 2);
            bP = (float)Math.Round(bValue / 255, 2);


            kValue = 1 - new List<float>() { rP, gP, bP }.Max();
            cmykKSlider.Value = kValue * 100;

            xd.Text = kValue.ToString();
            xd1.Text = cValue.ToString();
            xd2.Text = mValue.ToString();
            xd3.Text = yValue.ToString();

            if (kValue != 1)
            {
                cValue = (float)Math.Round((1f - rP - kValue) / (1 - kValue), 2);
                cmykCSlider.Value = Math.Round(cValue * 100);
                mValue = (float)Math.Round((1f - gP - kValue) / (1 - kValue), 2);
                cmykMSlider.Value = Math.Round(mValue * 100);
                yValue = (float)Math.Round((1f - bP - kValue) / (1 - kValue), 2);
                cmykYSlider.Value = Math.Round(yValue * 100);
            }
            //Cmax = Math.Max(Math.Max(rP, gP), bP);
            //Cmin = Math.Min(Math.Min(rP, gP), bP);
            //delta = Cmax - Cmin;

            //if (Cmax != 0)
            //    hsvSSlider.Value = Math.Round(delta / Cmax * 100);
            //else
            //    hsvSSlider.Value = 0;

            //hsvVSlider.Value = Math.Round(Cmax * 100);

            //if (delta == 0)
            //    hsvHSlider.Value = 0;
            //else if (Cmax == rP)
            //    hsvHSlider.Value = Math.Round(60 * ((gP - bP) / delta) % 6);
            //else if (Cmax == gP)
            //    hsvHSlider.Value = Math.Round(60 * ((bP - rP) / delta + 2));
            //else if (Cmax == bP)
            //    hsvHSlider.Value = Math.Round(60 * ((rP - gP) / delta + 4));


            changeColor();
        }

        private void changeColor()
        {
            colorPreview.Background = new SolidColorBrush(Color.FromRgb((byte)rValue, (byte)gValue, (byte)bValue));
            colorPreview.Foreground = new SolidColorBrush(Color.FromRgb((byte)(255 - rValue), (byte)(255 - gValue), (byte)(255 - bValue)));
            byte[] byteArray = new byte[3];
            byteArray[0] = (byte)rValue;
            byteArray[1] = (byte)gValue;
            byteArray[2] = (byte)bValue;
            colorPreview.Content = "#" + Convert.ToHexString(byteArray);
        }
    }
}
