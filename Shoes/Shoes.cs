using System;
using System.Globalization;
using System.Windows.Data;

namespace sizes
{
    class LookUp
    {
        static public float[,] sizes = new float[,]{
		    {34 ,215 ,2 ,3 ,4},
		    {34.5f ,215 ,2.5f ,3.5f ,4.5f},
		    {35 ,220 ,3 ,4 ,5},
		    {35.5f ,225 ,3.5f ,4.5f ,5.5f},
		    {36 ,225 ,4 ,5 ,6},
		    {36.5f ,230 ,4 ,5 ,6},
		    {37 ,235 ,4.5f ,5.5f ,6.5f},
		    {37.5f ,235 ,5 ,6 ,7},
		    {38 ,240 ,5.5f ,6.5f ,7.5f},
		    {38.5f ,245 ,5.5f ,6.5f ,7.5f},
		    {39 ,245 ,6 ,7 ,8},
		    {39.5f ,250 ,6.5f ,7.5f ,8.5f},
		    {40 ,255 ,7 ,8 ,9},
		    {40.5f ,255 ,7.5f ,8.5f ,9.5f},
		    {41 ,260 ,7.5f ,8.5f ,9.5f},
		    {41.5f ,265 ,8 ,9 ,10},
		    {42 ,265 ,8.5f ,9.5f ,10.5f},
		    {42.5f ,270 ,9 ,10 ,11},
		    {43 ,275 ,9.5f ,10.5f ,11.5f},
		    {43.5f ,275 ,9.5f ,10.5f ,11.5f},
		    {44 ,280 ,10 ,11 ,12},
		    {44.5f ,285 ,10.5f ,11.5f ,12.5f},
		    {45 ,285 ,11 ,12 ,13},
		    {45.5f ,290 ,11.5f ,12.5f ,13.5f},
		    {46 ,295 ,11.5f ,12.5f ,13.5f},
		    {46.5f ,295 ,12 ,13 ,14},
		    {47 ,300 ,12.5f ,13.5f ,14.5f},
		    {47.5f ,305 ,13 ,14 ,15},
		    {48 ,305 ,13 ,14 ,15},
		    {48.5f ,310 ,13.5f ,14.5f ,15.5f},
		    {49 ,315 ,14 ,15 ,16},
		    {49.5f ,315 ,14.5f ,15.5f ,16.5f},
		    {50 ,320 ,15 ,16 ,17}
        };
           
    }
    class LookUpUK : LookUp, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null) {
                float SliderValue = float.Parse(value.ToString()) ;
                for(int i = 0 ; i < sizes.Length; i++) {
                    if( sizes[i,0] == SliderValue ) {
                        return sizes[i,2] ;
                    }
                }
            }
            return -1 ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class LookUpUsMale : LookUp, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null) {
                float SliderValue = float.Parse(value.ToString()) ;
                for(int i = 0 ; i < sizes.Length; i++) {
                    if( sizes[i,0] == SliderValue ) {
                        return sizes[i,3] ;
                    }
                }
            }
            return -1 ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class LookUpUsFeMale : LookUp, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value != null) {
                float SliderValue = float.Parse(value.ToString()) ;
                for(int i = 0 ; i < sizes.Length; i++) {
                    if( sizes[i,0] == SliderValue ) {
                        return sizes[i,4] ;
                    }
                }
            }
            return -1 ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}