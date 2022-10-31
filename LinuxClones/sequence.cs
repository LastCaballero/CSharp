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
    public static void Main(string[] args)
    {
        if (args.Length == 2)
        {
            a = int.Parse(args[0]);
            b = int.Parse(args[1]);
            new Sequenz(a, b).Output();
        }
        else if (args.Length == 3)
        {
            a = int.Parse(args[0]);
            b = int.Parse(args[1]);
            s = int.Parse(args[2]);
            new Sequenz(a, b, s).Output();
        }
        else
        {
            Console.Error.Write("We need 2 or 3 args.\n");
            Console.Error.Write("Start, end and if you want steps.");
        }
    }
}
