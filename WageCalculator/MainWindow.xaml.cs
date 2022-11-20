using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Threading ;
using System.Windows.Data;


namespace wagecalculator
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double WagePerHour = 12 ;
        double Hours = 3 ;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        

    }

    class WagePerHourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "wage per hour: " + string.Format("{0:C}", value) ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class HoursPerMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "hours per month: " + string.Format("{0,4}", value) ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class MonthSum : IMultiValueConverter
    {
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(
                "{0,-20} {1,20:F2}","Wage per Month: ",
                (double)values[0] * (double)values[1]
            )  ;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class YearlySum : IMultiValueConverter
    {
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(
                "{0,-20} {1,20:F2}","Wage per Year: ",
                (double)values[0] * (double)values[1] * 12
            )  ;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



}


