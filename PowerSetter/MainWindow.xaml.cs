using System.Windows;
using System.Diagnostics ;

namespace energie
{
   
    public partial class MainWindow : Window
    {
        Process Power ;
        public MainWindow()
        {
            InitializeComponent();
            Power = new Process() ;
            ConfigureProcess() ;
            ShowScheme();
            
        }
        void ConfigureProcess(){
            Power.StartInfo.FileName = "powercfg.exe" ;
            Power.StartInfo.UseShellExecute = false ;
            Power.StartInfo.CreateNoWindow = true ;
            Power.StartInfo.RedirectStandardOutput = true ;
        }

        void SaveEnergie(object sender, RoutedEventArgs e)
        {
            Power.StartInfo.Arguments = "/setactive scheme_max" ;
            Power.Start() ;
            ShowScheme();
        }

        void BalancedMode(object sender, RoutedEventArgs e)
        {
            Power.StartInfo.Arguments = "/setactive scheme_balanced" ;
            Power.Start() ;
            ShowScheme();
        }
        
        void PowerMode(object sender, RoutedEventArgs e)
        {
            Power.StartInfo.Arguments = "/setactive scheme_min" ;
            Power.Start() ;
            ShowScheme();
        }
        string GetActiveMode() {
            Power.StartInfo.Arguments = "/getactivescheme" ;
            if( Power.Start() )
                return Power.StandardOutput.ReadLine() ;
            else
                return "No Information available..." ;
        }
        void ShowScheme() {
            Dispatcher.InvokeAsync(() => Scheme.Content = GetActiveMode() ) ;
        }
    }
}
