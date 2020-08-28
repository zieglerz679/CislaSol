using Cisla;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsdCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vítejte v ultra super NSD kalkulačce!", Console.ForegroundColor);

            Console.ForegroundColor = ConsoleColor.White;

            int a = LoadNumber();
            int b = LoadNumber();

            try
            {
                int result = Pocitadlo.NSD(a, b);
                Console.WriteLine($"\nNSD {a} a {b} je {result}", Console.ForegroundColor);
            }
#pragma warning disable 168
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nNSD {a} a {b} není definován", Console.ForegroundColor);
            }
#pragma warning restore 168

            Console.ReadKey();
        }

        static int LoadNumber()
        { 
            int x;
            while (true)
            {
                Console.Write("Zadej číslo: ");
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Musíte zadat celé číslo, které je maximálně {Int32.MaxValue}\n", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return x;
        }
    }
}
