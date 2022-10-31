using System.Net.Sockets;


class NetcatTalk
{
    TcpClient nc;
    NetworkStream stream;
    public NetcatTalk(string host, int port)
    {
        nc = new TcpClient(host, port);
        stream = nc.GetStream();
        new Thread(ReadFromNc).Start() ;
        StartTalk();
        
    }
    void StartTalk()
    {
        while (true)
        {
            string message = Console.ReadLine();
            foreach (char c in message)
            {
                stream.WriteByte((byte)c);
            }
            stream.WriteByte((byte)10);
            Thread.Sleep(1000) ;
        }
        


    }
    void ReadFromNc()
        {
            byte b;
            while (true)
            {
                while (stream.DataAvailable)
                {
                    b = (byte)stream.ReadByte();
                    Console.Write((char)b);
                }
                Thread.Sleep(1000);
            }
        }
}

class Start
{
    public static void Main(string[] args)
    {
        new NetcatTalk(args[0], int.Parse(args[1]));
    }
}
