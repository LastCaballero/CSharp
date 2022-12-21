using edifact ;
using messages ;





class Start {

    public static void Main(string[] args) {
        Console.Write(
            new Edifact( SampleMessages.One )
        ) ;
    }
}

