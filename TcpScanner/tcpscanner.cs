using System ;
using System.Net.Sockets ;
using System.Collections.Concurrent ;
using System.Threading.Tasks ;
using System.Threading ;


class ScanBubble {
	
	string 	Host ;
	int 	Start ;
	int 	End ;
	ConcurrentBag<int> open ;
	ConcurrentBag<int> closed ;
	
	public ScanBubble (string host, int start, int end ) {
		Host = host ;
		Start = start ;
		End = end ;
		open = new ConcurrentBag<int>() ;
		closed = new ConcurrentBag<int>() ;
		ScanRange() ;
	}
	void ShowOpen() {
		foreach( int p in open ) {
			Console.WriteLine( p + " open" ) ;
		}
	}
	void ShowClosed() {
		foreach( int p in closed ) {
			Console.WriteLine( p + " closed" ) ;
		}
	}
	
	void ScanRange() {
		int i = Start ;
		while ( i <= End ) {
			new Thread( () => ScanPort( i ) ).Start() ;
			Interlocked.Increment( ref i ) ;
		}
		Thread.Sleep(3000) ;
		ShowOpen() ;
		ShowClosed() ;
	}

	public void ScanPort ( int port ) {
		TcpClient spider = new TcpClient() ;
		try {
			spider.Connect( Host , port ) ;
		} catch { 
			closed.Add( port  ) ;
			return ;
		}
		open.Add( port ) ;
		spider.Dispose() ;
		
	} 
}


class Start {
	
	public static void Main( string[] args ) {
		string host = args[0] ;
		int start 	= int.Parse( args[1] ) ;
		int end 	= int.Parse( args[2] ) ;
		new ScanBubble( host, start, end ) ;
	}
}
