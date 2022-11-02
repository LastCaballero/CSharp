class Sequenz
{
    int begin, end, step = 1;
    int width;
    public Sequenz(int a, int b)
    {
        begin = a;
        end = b;
        width = Math.Max(("" + begin).Length, ("" + end).Length);
    }
    public Sequenz(int a, int b, int st) : this(a, b)
    {
        step = st;
    }
    public void Output()
    {
        string format = "{0," + width + "}";
        if (begin <= end)
        {
            for (int i = begin; i <= end; i += step)
            {
                Console.WriteLine(format, i);
            }
        }
        else {
            for (int i = begin; i >= end; i -= step)
            {
                Console.WriteLine(format, i);
            }
        }


    }
}

class Start
{
    static int a, b, s;
    public static int Main(string[] args)
    {
        if (args.Length < 2) {
            Console.Error.Write("At least 2 arguments are needed for a sequenz!\n");
            return 1 ;
        }
        else if (args.Length == 2)
        {
            try{
                a = int.Parse(args[0]);
                b = int.Parse(args[1]);
                new Sequenz(a, b).Output();
            } catch {
                 Console.Error.Write("The Args must be numbers!\n");
                 return 1 ;     
            }
            
            
        }
        else if (args.Length == 3)
        {
            try {
                a = int.Parse(args[0]);
                b = int.Parse(args[1]);
                s = int.Parse(args[2]);
            new Sequenz(a, b, s).Output();
            } catch {
                Console.Error.Write("The Args must be numbers!\n");
                return 1 ;
            }
            
        }
        else {
            Console.Error.Write("Something else went wrong!\n");
            return 1 ;
        }        
        return 0 ;
    }
}
