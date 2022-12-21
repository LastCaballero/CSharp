using System.Collections.Generic;

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

        public Edifact(string editext)
        {
            EdiAsText = editext;
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
            string sign = "" ;
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

namespace messages
{
    class SampleMessages
    {
        public static string One = @"UNA:+.? '
UNB+UNOC:3+Senderkennung+Empfaengerkennung+060620:0931+1++1234567'
UNH+1+ORDERS:D:96A:UN'
BGM+220+B10001'
DTM+4:20060620:102'
NAD+BY+++Bestellername+Strasse+Stadt++23436+xx'
LIN+1++Produkt Schrauben:SA'
QTY+1:1000'
UNS+S'
CNT+2:1'
UNT+9+1'
UNZ+1+1234567'";
    }
}