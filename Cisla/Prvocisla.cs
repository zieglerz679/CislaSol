using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisla
{
    public class Prvocisla
    {
        public static bool JePrvocislo(int x)
        {
            if (x < 2)
                throw new ArgumentOutOfRangeException("x", "Povolená hodnota je 2 a víc");
            else if (x == 2)
                return true;
            else if ((x & 1) == 0)  // testuji nejnizsi bit na 0 (nebo pomalejší modulo :))
                return false;
            else
            {
                int limit = (int)Math.Sqrt(x);
                for(int i = 3; i <= limit; i += 2)
                {
                    if (x % i == 0)
                        return false;
                }
                return true;
            }
        }

        public static int[] VratPrvocislaDo(int maximum)
        {
            if (maximum < 2)
                throw new ArgumentOutOfRangeException("maximum", $"Vstupní parametr je nevalidní. Je třeba zadat kladné celé číslo z intervalu <2;{Int32.MaxValue}.");

            int velikostPole = (maximum / 2) + (maximum % 2);
            //bool[] stavy = new bool[velikostPole];
            BitArray stavy = new BitArray(velikostPole);

            int limit = (int)Math.Sqrt(maximum) + 1;
            int limitIndex = (limit / 2) + (limit % 2);
            
            List<int> list = new List<int>();
            list.Add(2);

            for (int i = 1; i <= limitIndex; i++)
            {
                if (!stavy[i])
                {
                    int krok = 2 * i + 1;
                    for (int j = i+krok; j < stavy.Length; j+= krok)
                    {
                        stavy[j] = true;
                    }
                }
            }

            for (int i = 1; i < stavy.Length; i++)
            {
                if (!stavy[i])
                    list.Add(2 * i + 1);
            }

            return list.ToArray();
        }
    }
}
