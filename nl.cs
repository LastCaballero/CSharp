using System ;
using System.Collections.Generic ;
using System.IO ;

class Lines {
	private static List<string> _lines = new List<string>() ;
	
	public static List<string> list {
		get { return _lines ; }
	}
	
	public static int width {
		get { return _lines.Capacity.ToString().Length ; }
	}
}
class StdinWorker {
	string line ;
	List<string> lines ;

	public StdinWorker() {
		lines = Lines.list ;
	}

	public void DoPipe() {
		while ( (line = Console.ReadLine()) != null ) {
			lines.Add( line ) ;
		}	
	}
}

class FileExtractor {
	StreamReader for_file ;
	List<string> lines ;
	string line ;
	public FileExtractor ( string filename ) {
		lines = Lines.list ;
		for_file = new StreamReader(filename) ;
	}
	public void ReadLines() {
		while ( ( line = for_file.ReadLine() ) != null ) {
			lines.Add( line ) ;
		} 
	}
}

class OutPutter {
	List<string> lines ;
	public OutPutter() {
		lines = Lines.list ;
	}
	public void doOutput () {
		int i = 1 ;
		foreach ( string line in lines ) {
			Console.WriteLine(String.Format("{0," + Lines.width + ":D} {1:s}" ,i++, line ) ) ;
		}
	}
}

class Start {
	static void Main( string[] args ) {
		new StdinWorker().DoPipe() ;
		foreach ( string arg in args ) {
			if ( File.Exists(arg) ) { 
				new FileExtractor(arg).ReadLines() ;
			}
		}
		new OutPutter().doOutput() ;
	}
}
