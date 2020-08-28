using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisla
{
    public class Zlomek
    {
        //vyhodim setter = immutable object
        private int citatel;
        public int Citatel { get => citatel; }

        private int jmenovatel;
        public int Jmenovatel { get => jmenovatel; }


        public Zlomek(int citatel, int jmenovatel)
        {
            if (jmenovatel == 0)
            {
                throw new ArgumentException("jmenovatel", "Jmenovatel nesmí být roven nule");
            }

            if (jmenovatel < 0)
            {
                citatel = -citatel;
                jmenovatel = -jmenovatel;
            }

            if (citatel == 0)
            {
                this.citatel = 0;
                this.jmenovatel = 1;
                return;
            }

            if (jmenovatel == 1 || citatel == 1 || citatel == -1)
            {
                this.citatel = citatel;
                this.jmenovatel = jmenovatel;
                return;
            }

            int NSD = Pocitadlo.NSD(Math.Abs(citatel), jmenovatel);


            this.citatel = citatel / NSD;
            this.jmenovatel = jmenovatel / NSD;

        }

        public static Zlomek operator +(Zlomek z1, Zlomek z2)
        {
            return new Zlomek((z1.citatel * z2.jmenovatel) + (z2.citatel * z1.jmenovatel), (z1.jmenovatel * z2.jmenovatel));
        }

        public static Zlomek operator -(Zlomek z1, Zlomek z2)
        {
            return new Zlomek((z1.citatel * z2.jmenovatel) - (z2.citatel * z1.jmenovatel), (z1.jmenovatel * z2.jmenovatel));
        }

        public static Zlomek operator *(Zlomek z1, Zlomek z2)
        {
            return new Zlomek((z1.citatel * z2.citatel), (z1.jmenovatel * z2.jmenovatel));
        }

        public static Zlomek operator /(Zlomek z1, Zlomek z2)
        {
            if (z2.citatel == 0)
                throw new DivideByZeroException();
            
            return new Zlomek((z1.citatel * z2.jmenovatel), (z1.jmenovatel * z2.citatel));
        }

        public static implicit operator Zlomek(int cislo)
        {
            return new Zlomek(cislo, 1);
        }

        public static explicit operator int(Zlomek z)
        {
            return z.citatel / z.jmenovatel;
        }

        public static implicit operator double(Zlomek z)
        {
            return z.citatel / ((double)z.jmenovatel);
        }

        public override string ToString()
        {
            return $"[{citatel}/{jmenovatel}]";
        }
    }
}
