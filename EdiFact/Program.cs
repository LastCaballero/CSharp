using edifact;
using System.IO;


class Start
{
    public static void Main(string[] args)
    {
        if (args.Length < 1)
            Console.Error.WriteLine("we need at least one argument - path to a file.");
        
        if (File.Exists(args[0]))
            Console.Write(new Edifact(args[0]));
        else
            Console.Error.WriteLine("the file on the command line don´t exists... ") ;
    }
}

