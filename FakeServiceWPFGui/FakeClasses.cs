using System;
using System.Globalization;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Data;
using fakeservices ;

namespace fakeclasses
{

    class FakeService : TcpListener
    {

        static int Services = 0;
        static int Attacs = 0;
        MainWindow Link ;
        Task<TcpClient> Attacker ;

        public FakeService(int port, MainWindow link) : base(System.Net.IPAddress.Loopback, port)
        {
            Link = link ;
            ServiceUp() ;
        }

        void ServiceUp()
        {
            try
            {
                Start();
                Services++ ;
                Link.Dispatcher.InvokeAsync(
                        () => { Link.ServicesLabel.Content = Services.ToString() ; }
                    ) ;
                AcceptAttacker() ;
            }
            catch (SocketException)
            {

            }
        }

        void AcceptAttacker()
        {
            Attacker = AcceptTcpClientAsync() ;
            Attacker.GetAwaiter().OnCompleted(
                () => {
                    Attacs++ ;
                    Link.Dispatcher.InvokeAsync(
                        () => { Link.AttackLabel.Content = Attacs.ToString() ; }
                    ) ;
                    Attacker.Result.Client.Disconnect(true) ;
                    AcceptAttacker() ;
                }
            );
        }

    }


}