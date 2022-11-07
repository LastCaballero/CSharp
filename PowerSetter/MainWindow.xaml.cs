using System.Windows;
using System.Diagnostics ;



namespace energie
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        void SaveEnergie(object sender, RoutedEventArgs e)
        {
             Process.Start("powercfg.exe","/setactive scheme_max") ;
        }

        void BalancedMode(object sender, RoutedEventArgs e)
        {
            Process.Start("powercfg.exe","/setactive scheme_balanced") ;
        }
        
        void PowerMode(object sender, RoutedEventArgs e)
        {
             Process.Start("powercfg.exe","/setactive scheme_min") ;

        }
    }
}
