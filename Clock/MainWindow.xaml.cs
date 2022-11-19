using System.Windows;
using timesetter;

namespace clock
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            new TimeChanger(this) ;
        }
        

    }
}

