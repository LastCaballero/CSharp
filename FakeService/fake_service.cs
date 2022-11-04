using System.Net.Sockets ;
using System.Net ;
using System.Threading ;
using System ;

class FakeService: TcpListener {
	TcpClient Connection ;
	static int ConnectionCount = 0 ;	
	public FakeService ( int port ): base( IPAddress.Parse("127.0.0.1") , port) {}
	
	public void StartWaiting() {
		Start() ;
		ClientLookUp() ;
	}
	public void ClientLookUp () {
		Connection = AcceptTcpClient() ;
		Inform( ref Connection ) ;
		Connection.Close() ;
		Stop() ;
		Restart() ;
	}
	public void Restart() {
		Start() ;
		ClientLookUp() ;
	}
	public void Inform( ref TcpClient con ) {
		ConnectionCount++ ;
		Console.WriteLine("until now " + ConnectionCount + " suspicious connections" ) ;
	}
}


class Start {
	public static void Main () {
		int[] ports = { 4000, 4001, 4002, 4003 } ;
		foreach ( int po in ports ) {
			new Thread( new FakeService( po ).StartWaiting ).Start() ;
		}
	}
}



