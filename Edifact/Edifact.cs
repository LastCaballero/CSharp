using System.IO;
using System.Collections;

namespace edifact
{

    class Edifact
    {
        string EdiAsText;
        List<List<List<string>>> EdiAsNestedList;
        char Sp1 = '\'';
        char Sp2 = ':';
        char Sp3 = '+';
        char Dp = '.';
        char Ec = '?';


        public Edifact(string filename)
        {

            ReadEdi(filename);
            if (UnaExists())
            {
                SetSeparators();
            }
            ConvertToNestedList();
            GiveItOut() ;
        }
        void ReadEdi(string filename)
        {
            FileStream filestream;
            StreamReader reader;
            try
            {
                filestream = new FileStream(filename, FileMode.Open);
                reader = new StreamReader(filestream);
                EdiAsText = reader.ReadToEnd();
            }
            catch (System.Exception e)
            {
                EdiAsText = "";
                Console.Error.WriteLine("Something went wrong");
                Console.Error.WriteLine("The Problem is described below:\n");
                Console.Error.WriteLine(e.Message);
                return;
            }
        }
        void SetSeparators()
        {
            Sp1 = EdiAsText[8];
            Sp2 = EdiAsText[3];
            Sp3 = EdiAsText[4];
            Dp = EdiAsText[5];
            Ec = EdiAsText[6];
        }
        bool UnaExists()
        {
            return EdiAsText[0] == 'U' && EdiAsText[1] == 'N' & EdiAsText[2] == 'A';
        }

        void ConvertToNestedList()
        {
            EdiAsNestedList = EdiAsText.Split(Sp1).ToList().ConvertAll(
                e => e.Split(Sp2).ToList().ConvertAll(e => e.Split(Sp3).ToList())
            );
        }

		public void GiveItOut(){
			EdiAsNestedList.GetRange(1,EdiAsNestedList.Count - 1).ForEach(
				Line => {
                    Console.WriteLine() ;
                    Line.ForEach(
                        Segment => {
                            Segment.ForEach(
                                Data => { Console.Write(Data + "\t") ; }
                            ) ;
                        }
                    ) ;
                } 
			) ;
		}

		

        public override string ToString()
        {
            return EdiAsNestedList.ToString();
        }

    }
}

