using System.IO ;

namespace edifact
{

    class Edifact
    {
        string EdiAsText;
        char SegmentSeparator = '\'';
        char DataSegmentSeparator = ':';
        char DataSeparator = '+';
        char DeciPoint = '.';
        char EscapeCharacter = '?';

        
        public Edifact(string filename){
            
            FileStream filestream ;
            StreamReader reader ;
            try
            {
                filestream = new FileStream(filename, FileMode.Open) ;
                reader = new StreamReader( filestream ) ;
                EdiAsText = reader.ReadToEnd() ;    
            }
            catch (System.Exception e)
            {
                EdiAsText = "" ;
                Console.Error.WriteLine("Something went wrong");
                Console.Error.WriteLine("The Problem is described below:\n");
                Console.Error.WriteLine(e.Message) ;
                return ;
            }
            

            if (UnaExists())
            {
                SetSeparators();
            }
        }
        void SetSeparators()
        {
            SegmentSeparator = EdiAsText[8];
            DataSegmentSeparator = EdiAsText[3];
            DataSeparator = EdiAsText[4];
            DeciPoint = EdiAsText[5];
            EscapeCharacter = EdiAsText[6];
        }
        bool UnaExists()
        {
            return EdiAsText[0] == 'U' && EdiAsText[1] == 'N' & EdiAsText[2] == 'A';
        }
        public override string ToString() {
            string back = "" ;
            string[] lines = EdiAsText.Split(SegmentSeparator) ;
            string[] part ;
            string[] data ;
            for(int i = 1 ; i < lines.Length ; i++){
                part = lines[i].Split(DataSegmentSeparator) ;
                for(int ip = 0 ; ip < part.Length ; ip++){
                    data = part[ip].Split(DataSeparator) ;
                    for(int id = 0 ; id < data.Length ; id++){
                        back += data[id] + "\t" ;  
                    }
                }
                back += "\n\n" ;
            }

            return back ;
        }

    }
}

