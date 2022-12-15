using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;

namespace women_shoes
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
    }
}

namespace converters
{
    class LookUp
    {
        static public double[,] sizes = new double[,]{
                    { 21.5 ,4.5 ,35 ,2},
                    { 21.9 ,5 ,35.5 ,2.5},
                    { 22.5 ,5.5 ,36 ,3},
                    { 22.9 ,6 ,36.5 ,3.5},
                    { 23.2 ,6.5 ,37.5 ,4},
                    { 23.8 ,7 ,38 ,4.5},
                    { 24.1 ,7.5 ,38.5 ,5},
                    { 24.4 ,8 ,39 ,5.5},
                    { 25.1 ,8.5 ,40 ,6},
                    { 25.4 ,9 ,40.5 ,6.5},
                    { 25.7 ,9.5 ,41 ,7},
                    { 26 ,10 ,42 ,7.5},
                    { 26.4 ,10.5 ,42.5 ,8},
                    { 26.7 ,11 ,43 ,8.5},
                    { 27 ,11.5 ,44 ,9},
                    { 27.6 ,12 ,44.5 ,9.5},
                    { 27.9 ,12.5 ,45 ,10},
                    { 28.3 ,13 ,45.5 ,10.5 },
        };

    }
    class Centimeters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("Footsize in cm: {0:00.00}", double.Parse(value.ToString())) ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class LookUpUS : LookUp, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                double SliderValue = double.Parse(value.ToString());
                for (int i = 0; i < sizes.Length; i++)
                {
                    if (sizes[i, 0] == SliderValue)
                    {
                        return sizes[i, 1];
                    }
                }
            }
            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class LookUpEU : LookUp, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                double SliderValue = double.Parse(value.ToString());
                for (int i = 0; i < sizes.Length; i++)
                {
                    if (sizes[i, 0] == SliderValue)
                    {
                        return sizes[i, 2];
                    }
                }
            }
            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class LookUpUK : LookUp, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                double SliderValue = double.Parse(value.ToString());
                for (int i = 0; i < sizes.Length; i++)
                {
                    if (sizes[i, 0] == SliderValue)
                    {
                        return sizes[i, 3];
                    }
                }
            }
            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
