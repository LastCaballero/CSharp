using System.Windows;
using System.Windows.Controls;
using System ;
using System.Windows.Media ;

namespace fontviewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            
            foreach (var font in Fonts.SystemFontFamilies )
            {
                var combo_item = new ComboBoxItem();
                combo_item.Content = font;
                combo_item.FontFamily = font ;
                combo_item.FontSize = 16 ;
                Dispatcher.Invoke(
                    () => { Family.Items.Add(combo_item); }
                );

            }
        }

    }
}

