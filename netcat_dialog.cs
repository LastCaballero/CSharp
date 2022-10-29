using System ;
using System.Net.Sockets ;
using System.IO ;


class Contacter {
	
	public TcpClient 	NetCat 		{ get ; }
	public NetworkStream 	NCStream 	{ get ; }
	public StreamReader 	FromNetcat 	{ get ; }
	public StreamWriter 	ToNetcat 	{ get ; }
	
	public Contacter ( string host , int port ) {
		
		NetCat 		= new 	TcpClient( host, port ) ;	
		NCStream 	= NetCat.GetStream() ;
		FromNetcat 	= new 	StreamReader( NCStream ) ;
		
		ToNetcat	= new 	StreamWriter( NCStream ) ;
		ToNetcat.AutoFlush = true ;
			
		TalkToNetcat() ;
	
	}

	void TalkToNetcat () {
		string line ;
		while ( true )  {
			line = Console.ReadLine() ;
			ToNetcat.WriteLine( line ) ;
			ReadFromNetcat() ;
		}
	}

	void ReadFromNetcat () {
		string line ;
		if ( NCStream.DataAvailable ) {
			while ( true ) {
				line = FromNetcat.ReadLine() ;
				Console.WriteLine( line ) ;
				if ( ! NCStream.DataAvailable )
					break ;
			}
		}
	}

}



class Start {	
	public static void Main ( string[] args ) {
		new Contacter( args[0] , int.Parse(args[1]) ) ;	
	}
}
