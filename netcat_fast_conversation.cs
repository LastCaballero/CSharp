using System;
using System.Net.Sockets;
using System.IO;

class NetcatTalk
{
    TcpClient nc;
    NetworkStream stream;
    public NetcatTalk(string host, int port)
    {
        nc = new TcpClient(host, port);
        stream = nc.GetStream();
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
            byte b;
            while (stream.DataAvailable)
            {
                b = (byte)stream.ReadByte();
                Console.Write((char)b);
            }
            stream.WriteByte((byte)10);
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
