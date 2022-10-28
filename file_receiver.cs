using System.Net ;
using System.Net.Sockets ;
using System.IO ;

class NetcatContact {
	TcpListener me ;
	TcpClient netcat ;
	IPAddress my_ip ;
	public NetworkStream nc_stream { get ; } 

	public NetcatContact( int port ) {
		my_ip = IPAddress.Parse("127.0.0.1");
		me = new TcpListener( my_ip, port ) ;
		me.Start() ;
		netcat = me.AcceptTcpClient() ;
		nc_stream = netcat.GetStream() ;
	}
}

class StreamExchange {
	StreamReader outside ;
	StreamWriter inside ;
	NetworkStream nc_stream ;
	public StreamExchange ( string filename , ref NetworkStream nc ) {
		outside = new StreamReader( nc ) ;
		inside = new StreamWriter( filename ) ;
		nc_stream = nc ;
	}
	public void Exchange () {
		while ( nc_stream.DataAvailable ) {
			inside.WriteLine( outside.ReadLine() ) ;			
		}
	}

}


class Start {
	static int port ;
	static string filename ;
	public static void Main ( string[] args ) {
		port = int.Parse( args[0] ) ;
		filename = args[1] ;
		NetworkStream nc = new NetcatContact( port ).nc_stream ;
		new StreamExchange( filename, ref nc ).Exchange() ;
	}
}
