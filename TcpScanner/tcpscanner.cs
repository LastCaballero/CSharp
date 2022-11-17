using System ;
using System.Net.Sockets ;
using System.Collections.Concurrent ;
using System.Threading.Tasks ;


class ScanBubble {
	
	string 	Host ;
	int 	Start ;
	int 	End ;
	private ConcurrentBag<int> OpenPorts ;
	public ConcurrentBag<int> ports {
		get { return OpenPorts ; }
	}
	
	public ScanBubble (string host, int start, int end ) {
		Host = host ;
		Start = start ;
		End = end ;
		OpenPorts = new ConcurrentBag<int>() ;
	}
	
	public async Task ScanRange() {
		for ( int i = Start ; i <= End ; i++ ) {
			ScanPort ( i ) ;						
		}
	}

	public async Task ScanPort ( int port ) {
		TcpClient spider = new TcpClient() ;
		try {
			spider.Connect( Host , port ) ;
		} catch { 
			return ;
		}
		if ( spider.Connected ) {
			OpenPorts.Add( port ) ;
			spider.Dispose() ;
		}
		
	}
}


class Start {
	static ScanBubble bubble ;

	static async Task RangeScan( ) {
		await bubble.ScanRange() ;
		ShowPorts() ;
	}
	static async Task ShowPorts() {
		foreach ( int member in bubble.ports ) {
			Console.WriteLine( member ) ;
		}	
	}
	
	public static void Main( string[] args ) {
		string host = args[0] ;
		int start 	= int.Parse( args[1] ) ;
		int end 	= int.Parse( args[2] ) ;
		bubble = new ScanBubble( host, start, end ) ;
		RangeScan() ;
	}
}
