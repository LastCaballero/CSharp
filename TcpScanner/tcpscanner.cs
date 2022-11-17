using System ;
using System.Net.Sockets ;
using System.Threading.Tasks ;


class ScanBubble {
	
	string 	Host ;
	int 	Start ;
	int 	End ;
	
	
	public ScanBubble (string host, int start, int end ) {
		Host = host ;
		Start = start ;
		End = end ;
	}
	
	public void ScanRange() {
		for ( int i = Start ; i <= End ; i++ ) {
			ScanPort ( i ) ;						
		}
	}

	public async Task ScanPort ( int port ) {
		TcpClient spider = new TcpClient() ;
		try {
			spider.Connect( Host , port ) ;
		} catch { 
			Console.WriteLine( port + "\tclosed" ) ;
			return ;
		}
		if ( spider.Connected ) {
			Console.WriteLine( port + "\topen" ) ;
			spider.Dispose() ;
		}
		
	}
}


class Start {
	static ScanBubble bubble ;
	
	public static void Main( string[] args ) {
		string host = args[0] ;
		int start 	= int.Parse( args[1] ) ;
		int end 	= int.Parse( args[2] ) ;
		bubble = new ScanBubble( host, start, end ) ;
		Console.WriteLine("Ports at " + host) ;
		bubble.ScanRange() ;
	}
}
