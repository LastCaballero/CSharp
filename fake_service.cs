using System.Net.Sockets ;
using System.Net ;
using System.Threading ;
using System ;

class FakeService: TcpListener {
	TcpClient Connection ;
	
	public FakeService ( int port ): base( IPAddress.Parse("127.0.0.1") , port) {}
	
	public void StartWaiting() {
		Start() ;
		ClientLookUp() ;
	}
	public void ClientLookUp () {
		Connection = AcceptTcpClient() ;
		Inform( ref Connection ) ;
		Stop() ;
		Connection.Client.Disconnect( true ) ;
		Restart() ;
	}
	public void Restart() {
		Start() ;
		ClientLookUp() ;
	}
	public void Inform( ref TcpClient con ) {
		Console.WriteLine( con ) ;
	}
}


class Start {
	public static void Main () {
		new Thread( new FakeService(4000).StartWaiting ).Start() ;
		new Thread( new FakeService(4001).StartWaiting ).Start() ;
	}
}



