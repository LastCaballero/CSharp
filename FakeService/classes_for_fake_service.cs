namespace fakeservice_classes
{
    using System.Net.Sockets;
    using System.Net;
    using System.Collections.Generic ;
    class FakeService
    {
        static int Count ;
        static IPAddress MyIp = IPAddress.Parse("127.0.0.1") ;
        TcpListener Fake ;
        int port ;
        public FakeService( int pnm ){
            port = pnm ;
            Fake = new TcpListener(MyIp, port) ;
            StartListening() ;
        }
        private void Recreate() {
            Fake = new TcpListener(MyIp, port) ;
            StartListening() ;
        }
        private void StartListening() {
            Fake.Start() ;
            StartCounting() ;
        }
        private void StartCounting() {
            Socket other = Fake.AcceptSocket() ;
            if (other != null) {
                Count++ ;
            }
            Destroy() ;
        }
        private void Destroy () {
            Fake.Server.Disconnect(false) ;
            Fake.Server.Dispose() ;
            Fake.Stop() ;
            Recreate() ;
        }
    }
    class FakeServiceContainer {
        static List<FakeService> _list ;
        public static List<FakeService> list { 
            get { return _list ; }
        }
    }

}
