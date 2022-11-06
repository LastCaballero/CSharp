using System.Windows;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Generic ;



namespace fakeservices
{
    using fakeservice_classes;

    public partial class MainWindow : Window
    {
        int ServiceCount = 0 ;
        int AttackCount = 0 ;
        List<Thread> threads = new List<Thread>() ;
        List<FakeService> fakes = new List<FakeService>() ;

        public MainWindow()
        {

            InitializeComponent();
            this.InfoText.Content="Running services:\n\nAttacks:" ;
            this.InfoNumbers.Content= ServiceCount.ToString() + "\n\n" + AttackCount ;


        }
        public void Increase(object sender, RoutedEventArgs e)
        {
            int cont = int.Parse(this.NumServices.Content.ToString());
            cont++;
            this.NumServices.Content = cont;
        }
        public void Decrease(object sender, RoutedEventArgs e)
        {
            int cont = int.Parse(this.NumServices.Content.ToString());
            if (cont != 0)
            {
                cont--;
            }

            this.NumServices.Content = cont;
        }
        public void StartServices(object sender, RoutedEventArgs e) {
            int Start = 4000 ;
            int Count = (int)this.NumServices.Content ;
            int End = Start + Count ;
            FakeService fa ;
            Thread tr ;
            for (int i = 4000; i < End; i++) {
                fa = new( i, this ) ;
                tr = new(fa.StartCycle);
                tr.Start() ;
                fakes.Add(fa) ;
                threads.Add(tr) ;
            }
            
        }

        public void StopServices(object sender, RoutedEventArgs e) {

        }
        public void IncreaseServiceCount() {
            ServiceCount++ ;
            setInfo() ;
        }
        public void IncreaseAttackCount() {
            AttackCount++ ;
            setInfo() ;
        }
        public void setInfo() {
            this.InfoNumbers.Content= ServiceCount.ToString() + "\n\n" + AttackCount ;
        }

    }
}

namespace fakeservice_classes
{
    
    using fakeservices ;
    
    class FakeService{
        IPAddress Ip = IPAddress.Parse("127.0.0.1") ;
        int port ;
        MainWindow Main ;
        TcpListener TcpFake { get ;} 
        public FakeService( int port, MainWindow main ) {
            this.port = port ;
            Main = main ;
            TcpFake = new(Ip, this.port) ;
            Main.IncreaseServiceCount() ;
        }
        public void StartCycle () {
            TcpFake.Start() ;
            TcpFake.AcceptTcpClient() ;
            Main.IncreaseAttackCount() ;
            TcpFake.Stop() ;
            TcpFake.Server.Dispose() ;
            new FakeService(port, Main) ;
        }
        
        
    }
    
}
