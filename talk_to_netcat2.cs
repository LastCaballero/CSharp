using System;
using System.Net.Sockets;
using System.IO;


class Contacter
{
	
    TcpClient NetCat ;
    NetworkStream NCStream ;
    StreamReader FromNetcat ;
    StreamWriter ToNetcat ;
	Queue<string> messages ;
    public Contacter(string host, int port)
    {
		messages = new Queue<string>() ;
        NetCat = new TcpClient(host, port);
        NCStream = NetCat.GetStream();
        FromNetcat = new StreamReader(NCStream);

        ToNetcat = new StreamWriter(NCStream);

		new Thread(ReadFromNetcat).Start() ;
        TalkToNetcat();

    }

    void TalkToNetcat()
    {
        string line;
        while (true)
        {
			while( messages.Count != 0) {
				ToNetcat.WriteLine(messages.Dequeue());
			}
            line = Console.ReadLine();
            ToNetcat.WriteLine(line);
			ToNetcat.Flush() ;
        }
    }

    void ReadFromNetcat()
    {
        string line;
        while ( true )
        {
			if(NCStream.DataAvailable){
				line = FromNetcat.ReadLine();
				messages.Enqueue(line) ;
			}
			Thread.Sleep(1000) ;
        }

    }

}

class Start
{
    public static void Main(string[] args)
    {		
        new Contacter(args[0], int.Parse(args[1]));
    }
}
