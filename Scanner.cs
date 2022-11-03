using System ;
using System.Net.Sockets ;
using System.Net ;
using System.Collections.Generic ;

class Information {
	private static List<Result> _results = new List<Result>()  ;
	public static List<Result> results { get { return _results ; } }
	public static void ShowResults () {
		foreach ( Result r in _results ) {
			Console.WriteLine("{0} {1}", r.endp, r.port ) ;	
		}	
	}
	
}

public class Result {
	public string endp { get ; }
	public int port { get ; }
	public Result ( string enp , int p ) {
		this.endp = enp ;
		this.port = p ;
	}
}

class ScanAction {
	IPHostEntry target = null ;
	int StartPort = -1 ;
	int EndPort = -1 ;
	private ScanAction ( string host ) {
		target = Dns.GetHostEntry(host) ;
	}
	public ScanAction ( string host, int start ) : this(host) {
		StartPort = start ;
	}
	public ScanAction ( string host, int start, int end ) : this(host) {
		StartPort = start ;
		EndPort = end ;
	}
	public void DoIt ( ) {
		if ( target != null && StartPort != -1 && EndPort != -1 ) {
			foreach( IPAddress address in target.AddressList ) {
				for ( int i = StartPort ; i <= EndPort ; i++ ) {
					IPEndPoint ip_target = new IPEndPoint( address, i );
					Socket me = SocketFactory.GetSocket(
						ip_target.AddressFamily,
						SocketType.Stream, 
						ProtocolType.Tcp 
					) ;
					me.Connect( ip_target ) ;
					if ( me.Connected ) {
						Information.results.Add(
							new Result(	ip_target.Address.ToString(), i )
						);
						me.Disconnect(false) ;
						me.Close() ;
					}
				}
			}
		}
		else if ( target != null && StartPort != -1 && EndPort == -1 ) {
			foreach( IPAddress address in target.AddressList ) {
				IPEndPoint ip_target = new IPEndPoint( address, StartPort );
					Socket me = SocketFactory.GetSocket(
						ip_target.AddressFamily,
						SocketType.Stream, 
						ProtocolType.Tcp 
					) ;
					me.Connect( ip_target ) ;
					if ( me.Connected ) {
						Information.results.Add(
							new Result(	ip_target.Address.ToString(), StartPort )
						);
						me.Disconnect(false) ;
						me.Close() ;
					}
			}
		}
	}

}


class SocketFactory {
	public static Socket GetSocket (AddressFamily family, SocketType type, ProtocolType protocol) {
		return new Socket( family, type, protocol ) ;
	}
	public static Socket GetSocket( SocketType type , ProtocolType protocol ) {
		return new Socket ( type, protocol ) ;
	}
}




class Start {
	
	public static int Main( string[] args ){
		if ( args.Length < 2 ) {
			Console.Error.WriteLine( "We need at least 2 arguments. The host and a port..." ) ;
			return 1 ;
		}
		else if ( args.Length == 2 ) {
			string host ;
			int port ;
			try {
				host = args[0] ;
				port = int.Parse( args[1] ) ;
			} catch {
				Console.Error.WriteLine( "Second argument must be a number..." ) ;
				return 1 ;
			}
			new ScanAction( host, port ).DoIt() ;
			return 0 ;
		}
		else if ( args.Length == 3 ) {
			string host ;
			int start, end ;
			try {
				host = args[0] ;
				start = int.Parse( args[1] ) ;
				end = int.Parse( args[2] ) ;
				if ( ! (start < end) ) {
					Console.Error.WriteLine( "start port must be smaller than end port..." ) ;
					return 1 ;
				}
			} catch {
				Console.Error.WriteLine( "Second and third argument must be a number..." ) ;
				return 1 ;
			}
			new ScanAction( host, start, end ).DoIt() ;
			return 0 ;
		} else {
			Console.Error.WriteLine( "Something else went wrong..." ) ;
		}
		return 0 ;
	}
}
