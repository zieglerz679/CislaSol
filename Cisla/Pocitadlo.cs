using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisla
{
    public class Pocitadlo
    {
        public static int NSD(int a, int b)
        {
            if(a == 0 || b == 0)
            {
                throw new ArgumentException("Vstupní parametry jsou nevalidní. Je třeba zadat dvě celá čísla různá od nuly.");
            }

            if (a < 0) a *= -1;
            if (b < 0) b *= -1;

            while (a != b)
            {
                if(a < b)
                {
                    b -= a;
                }
                else
                {
                    a -= b;
                }
            }
            
            return a;
        }
    }
}
