using Cisla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlomekTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Zlomek z1 = new Zlomek(4, 8);
            Zlomek z2 = new Zlomek(3, 9);
            Zlomek z3 = z1 + z2;

            Console.WriteLine($"{z1} + {z2} = {z3}");
            Console.WriteLine($"{z1} - {z2} = {z1 - z2}");
            Console.WriteLine($"{z1} * {z2} = {z1 * z2}");
            Console.WriteLine($"{z1} / {z2} = {z1 / z2}");

            Console.ReadKey();
        }
    }
}
