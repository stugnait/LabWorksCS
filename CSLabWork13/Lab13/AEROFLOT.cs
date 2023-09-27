using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Documents;

namespace Lab13;

public struct AEROFLOT
{
    
    public string CITY;
    public string NUM;
    public string TYPE;
    
    public AEROFLOT(string city, string num, string type)
        {
            CITY = city;
            NUM = num;
            TYPE = type;
        }

    public string ToSaveFormat()
    {
        return CITY + ";" + NUM + ";" + TYPE + "\n";
    }

    public override string ToString()
    {
        return CITY + ";" + NUM + ";" + TYPE + "\n";
    }
}

