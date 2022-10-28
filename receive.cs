using System.Net.Sockets ;
using System.Net ;

class FileReceiver{
    
    StreamWriter to_file ;
    TcpListener me ;
    IPAddress my_ip = IPAddress.Parse("127.0.0.1");
    TcpClient netcat ;
    public FileReceiver(int port, string filename) {
        me = new TcpListener(my_ip,port) ;
        to_file = new StreamWriter(filename) ;
        StartService() ;
    }
    public void StartService () {
        me.Start() ;
        netcat = me.AcceptTcpClient() ;
        NetworkStream stream_netcat = netcat.GetStream() ;
        Reading(ref stream_netcat) ;
    }
    public void Reading(ref NetworkStream nc) {
        StreamReader reader = new StreamReader(nc) ;
        string line ;
        while(nc.DataAvailable) {
            line = reader.ReadLine() ;
            to_file.WriteLine(line) ;
        }
        nc.Close();
        to_file.Close() ;
        netcat.Close() ;
    }
}


class Start {
    
    static string? filename ;
    static int port ;
    static public void Main(string[] args){
        port = int.Parse(args[0]) ;
        filename = args[1] ;
        FileReceiver x = new FileReceiver(port, filename);
    }
}
