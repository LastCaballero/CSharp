using System.Windows;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Threading.Tasks ;
using System.Collections.Generic ;



namespace fakeservices
{
    
    public partial class MainWindow : Window
    {
        int ServiceCount = 0 ;
        int AttackCount = 0 ;
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
            for ( int i = Start; i < End ; i++) {
                fakes.Add( new FakeService( i, this ) ) ;
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

    class FakeService{

        IPAddress Ip = IPAddress.Parse("127.0.0.1") ;
        int port ;
        TcpListener TcpFake { get ;}
        Task<TcpClient> ClientTask ;
        MainWindow Main ; 
        public FakeService( int port, MainWindow main ) {
            Main = main ;
            this.port = port ;        
            TcpFake = new(Ip, this.port) ;
            TcpFake.Start() ;
            new Thread(Accept).Start() ;        
        }
        public void Accept () {
            ClientTask = TcpFake.AcceptTcpClientAsync();
            Main.IncreaseServiceCount() ;
            new Thread(TestForResult).Start() ;
        }
        public void TestForResult() {
            do {
                if( ClientTask.IsCompleted ) {
                    ClientTask.Result.Dispose() ;
                    Main.IncreaseAttackCount() ;
                    break ;
                }
                Thread.Sleep(1000) ;
            } while( true ) ;
            Accept() ;
        }
        
        
    }
}


